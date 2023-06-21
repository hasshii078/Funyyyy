using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //LoadScene���g�����߂ɕK�v
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

    public int enemyHP; //�G�̍ő�HP
    private int wkHP; //�G�̌��݂�HP
    public Slider hpSlider; //HP�o�[

    // Start is called before the first frame update
    public void OnpuHit1()
    {
        wkHP -= 10;
        hpSlider.value = (float)wkHP / (float)enemyHP;//�X���C�_�͂O?1.0�ŕ\�����邽�ߍő�HP�Ŋ����ď����_�����ɕϊ�
                                                      // HP��0�ȉ��ɂȂ����ꍇ�A���������
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

        hpSlider.value = (float)enemyHP; //HP�o�[�̍ŏ��̒l(�ő�HP)��ݒ�
        wkHP = enemyHP; //���݂�HP���ő�HP�ɐݒ�
    }

    // Update is called once per frame
    void FixedUpdate()
    {//�����̐ݒ�
        /*int xVector = -1;
        if (rightTleftF) {
            xVector = 1;
            transform.localScale = new Vector3(3, 3, 1);
        }
        else {
            transform.localScale = new Vector3(-3, 3, 1);
        }
        rb.velocity = new Vector2(xVector*speed,-gravity);

        //���E�ǂ���ɓ�����
        if (this.transform.position.x < playerTransform.position.x)
        {
            rightTleftF = true;
        }
        else { 
            rightTleftF= false;
        }*/
    }
}
