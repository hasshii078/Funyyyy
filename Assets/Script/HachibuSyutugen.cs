using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HachibuSyutugen : MonoBehaviour
{

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
        buki.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //V�L�[�������ꂽ�甪�������\��
        if (Input.GetKey(KeyCode.V))
        {
            buki.SetActive(true);//������������\������
            Attack();
        }
        else
        {
            Invoke("BukiHide", 0.3f);//���{�^�������㐔�b�҂��Ă��甪���������B��
        }
    }
    void Attack()
    {
        
            
        
    }
}
