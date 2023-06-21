using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //LoadSceneを使うために必要
using UnityEngine.UI;

public class BachMove : MonoBehaviour
{
    public float speed;
    public float gravity;
    public GameObject player;
    Transform playerTransform;
    //public bool nonVisibleAct;

    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private bool rightTleftF = true;

    public int enemyHP; //敵の最大HP
    private int wkHP; //敵の現在のHP
    public Slider hpSlider; //HPバー

    // Start is called before the first frame update
    public void OnpuHit1()
    {
        wkHP -= 10;
        hpSlider.value = (float)wkHP / (float)enemyHP;//スライダは０?1.0で表現するため最大HPで割って少数点数字に変換
                                                      // HPが0以下になった場合、自らを消す
        if (wkHP == 0)
        {
            Destroy(this.gameObject,3f);
            SceneManager.LoadScene("ClearScene");
            //Invoke("LoadClearScene", 4f);
        }
            
    }
    /*void LoadClearScene() 
    {
        SceneManager.LoadScene("ClearScene");
    }*/

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        playerTransform = player.transform;

        hpSlider.value = (float)enemyHP; //HPバーの最初の値(最大HP)を設定
        wkHP = enemyHP; //現在のHPを最大HPに設定
    }

    // Update is called once per frame
    void FixedUpdate()
    {//動きの設定
        /*int xVector = -1;
        if (rightTleftF) {
            xVector = 1;
            transform.localScale = new Vector3(3, 3, 1);
        }
        else {
            transform.localScale = new Vector3(-3, 3, 1);
        }
        rb.velocity = new Vector2(xVector*speed,-gravity);

        //左右どちらに動くか
        if (this.transform.position.x < playerTransform.position.x)
        {
            rightTleftF = true;
        }
        else { 
            rightTleftF= false;
        }*/
    }
}
