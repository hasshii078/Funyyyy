using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UI���g���Ƃ��ɏ����܂��B
using UnityEngine.SceneManagement; //LoadScene���g�����߂ɕK�v

public class SyuzinkouController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid2D;
    float jumpForce = 1200.0f;�@�@//�W�����v�̍���
    float walkForce = 120.0f;�@�@ //�ړ����x
    float maxWalkSpeed = 5.0f;   //�ő�ړ����x
    private bool canJump = true;
    public Rigidbody objectToThrow;
    public float throwForce = 10f;
    Animator animator;
    public GameObject OnpuPrefab; //�����̃v���n�u
    public float MoveSpeed = 20.0f;
    
    public bool lr;//�g���L�������E�ǂ���������Ă��邩������
    private TimeScript timeScript;

    public int onpuHP; //��l���̍ő�HP
    private static int wkHP; //��l���̌��݂�HP
    public Slider hpSlider; //HP�o�[


    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();

        timeScript = GetComponent<TimeScript>();

        hpSlider.value = (float)onpuHP; //HP�o�[�̍ŏ��̒l(�ő�HP)��ݒ�
        wkHP = onpuHP; //���݂�HP���ő�HP�ɐݒ�
    }

    // Update is called once per frame
    void Update()
    {
        //�W�����v����
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            canJump = false;
        }

        //���E�ړ�
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

        //�v���C��̑��x
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //�X�s�[�h����
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //���������ɉ����Ĕ��]
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //�v���C���̑��x�ɉ����ăA�j���[�V�������x��ς���
        /*if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }*/

        //��ʊO�ɏo����ŏ�����
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameOverScene");
        }

        //B���������特������
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(OnpuPrefab, transform.position, Quaternion.identity);
            //this.animator.SetBool("attack",true);

        }

        //V���������犙�ōU��
        if (Input.GetKey(KeyCode.V))//����GetKeyDown
        {
            this.animator.SetBool("attack", true);

        }
        else
        {
            this.animator.SetBool("attack", false);
        }
    }

    //�W�����v�Œ��n������ĂуW�����v�ł���悤��
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
            hpSlider.value = (float)wkHP / (float)onpuHP;//�X���C�_�͂O?1.0�ŕ\�����邽�ߍő�HP�Ŋ����ď����_�����ɕϊ�
                                                          // HP��0�ȉ��ɂȂ����ꍇ�A���������
            if (wkHP == 0)
            {
               SceneManager.LoadScene("GameOverScene");
            }
        }

    }

    //�S�[���ɓ��B
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("flag"))
        {
            SceneManager.LoadScene("BossScene");
        }
    }

    
}


