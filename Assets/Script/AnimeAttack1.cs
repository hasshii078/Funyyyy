using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeAttack : MonoBehaviour
{
    private Animator anim = null;

    //�����������U���������\�����邽�߂ɔ��������������ϐ������
    public GameObject buki;//��

    //�����������֐���
    void BukiHide()
    {
        buki.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�X�y�[�X�L�[�������ꂽ��U������(attack��true�ɂ��ăA�j���[�V�����Đ�)
        if (Input.GetKey(KeyCode.Space))
        {
            buki.SetActive(true);//������������\������
            anim.SetBool("attack", true);
            
        }
        else {
            anim.SetBool("attack", false);
            Invoke("BukiHide", 0.3f);//���{�^�������㐔�b�҂��Ă��甪���������B��
        }
    }
}
