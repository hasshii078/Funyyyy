using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIを使うときに書きます。
using UnityEngine.SceneManagement; //LoadSceneを使うために必要

public class SyuzinkouController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid2D;
    float jumpForce = 1200.0f;　　//ジャンプの高さ
    float walkForce = 120.0f;　　 //移動速度
    float maxWalkSpeed = 5.0f;   //最大移動速度
    private bool canJump = true;
    public Rigidbody objectToThrow;
    public float throwForce = 10f;
    Animator animator;
    public GameObject OnpuPrefab; //音符のプレハブ
    public float MoveSpeed = 20.0f;
    
    public bool lr;//ト音記号が左右どちらを向いているかを示す
    private TimeScript timeScript;

    public int onpuHP; //主人公の最大HP
    private static int wkHP; //主人公の現在のHP
    public Slider hpSlider; //HPバー


    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();

        timeScript = GetComponent<TimeScript>();

        hpSlider.value = (float)onpuHP; //HPバーの最初の値(最大HP)を設定
        wkHP = onpuHP; //現在のHPを最大HPに設定
    }

    // Update is called once per frame
    void Update()
    {
        //ジャンプする
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            canJump = false;
        }

        //左右移動
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
            lr = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
            lr = true;
        }

        /*if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;*/

        //プレイやの速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //スピード制限
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //動く方向に応じて反転
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //プレイヤの速度に応じてアニメーション速度を変える
        /*if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }*/

        //画面外に出たら最初から
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameOverScene");
        }

        //Bを押したら音符発射
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(OnpuPrefab, transform.position, Quaternion.identity);
            //this.animator.SetBool("attack",true);

        }

        //Vを押したら鎌で攻撃
        if (Input.GetKey(KeyCode.V))//元はGetKeyDown
        {
            this.animator.SetBool("attack", true);

        }
        else
        {
            this.animator.SetBool("attack", false);
        }
    }

    //ジャンプで着地したら再びジャンプできるように
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("gosenhu"))
        {
            canJump = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            canJump = true;
            wkHP -= 20;
            hpSlider.value = (float)wkHP / (float)onpuHP;//スライダは０?1.0で表現するため最大HPで割って少数点数字に変換
                                                          // HPが0以下になった場合、自らを消す
            if (wkHP == 0)
            {
               SceneManager.LoadScene("GameOverScene");
            }
        }

    }

    //ゴールに到達
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("flag"))
        {
            SceneManager.LoadScene("BossScene");
        }
    }

    
}


