using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeHachibuAttack : MonoBehaviour
{
    //�A�j���[�^�[�������邽�߂̕ϐ�
    private Animator animh;
   
    // Start is called before the first frame update
    void Start()
    {
        animh = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //V�L�[�������ꂽ��U������(attack��true�ɂ��ăA�j���[�V�����Đ�)
        if (Input.GetKey(KeyCode.O))
        {
            animh.SetBool("Attack",true);
           
        }
        else
        {
            animh.SetBool("Attack", false);
        }
    }
}
