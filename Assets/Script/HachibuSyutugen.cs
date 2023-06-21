using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HachibuSyutugen : MonoBehaviour
{

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
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vキーが押されたら八分音符表示
        if (Input.GetKey(KeyCode.V))
        {
            buki.SetActive(true);//★八分音符を表示する

        }
        else
        {
            Invoke("BukiHide", 0.3f);//★ボタン押下後数秒待ってから八分音符を隠す
        }
    }
}
