using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeAttack : MonoBehaviour
{
    private Animator anim = null;

    //八分音符を攻撃時だけ表示するために八分音符を示す変数を作る
    public GameObject buki;//★

    //音符を消す関数★
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
        //スペースキーが押されたら攻撃する(attackをtrueにしてアニメーション再生)
        if (Input.GetKey(KeyCode.Space))
        {
            buki.SetActive(true);//★八分音符を表示する
            anim.SetBool("attack", true);
            
        }
        else {
            anim.SetBool("attack", false);
            Invoke("BukiHide", 0.3f);//★ボタン押下後数秒待ってから八分音符を隠す
        }
    }
}
