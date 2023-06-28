using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeHachibuAttack : MonoBehaviour
{
    //アニメーターをいじるための変数
    private Animator animh;
   
    // Start is called before the first frame update
    void Start()
    {
        animh = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vキーが押されたら攻撃する(attackをtrueにしてアニメーション再生)
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
