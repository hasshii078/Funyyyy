using UnityEngine;
using System.Collections;

public class OnpuHitHard : MonoBehaviour
{
    //code.lrを代入する変数Lr Start内での初期化だとFixedUpdateの実行に間に合わずエラーが出るのでここで宣言する
    private bool Rr;
    public static bool band_bakuhatsu = false;//爆発したかどうか

    void Start()
    {
        //SyuzinkouControllerからパブリック変数lrを持ってくる
        GameObject Toonkigou;
        SyuzinkouController code;
        SyuzinkouControllerHard codeH;
        Toonkigou = GameObject.Find("toonkigou");
        codeH = Toonkigou.GetComponent<SyuzinkouControllerHard>();
        //Lr = code.lr;
        Rr = codeH.lr;
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    void FixedUpdate()
    {
        //ト音記号の向く方向に発射される
        if (Rr)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 0);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(20, 0);
        }

    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.GetComponent<BandmanController>())
        {
            band_bakuhatsu = true;//音を出すための変数
            trigger.gameObject.GetComponent<BandmanController>().OnpuHit1();
            Destroy(this.gameObject, 0.1f);
            Invoke("ReturnFalse", 0.01f);//すぐfalseに戻す

        }
        
        if (trigger.gameObject.GetComponent<BachMoveHard>())
        {
            trigger.gameObject.GetComponent<BachMoveHard>().OnpuHit2();
            Destroy(this.gameObject);
        }
    }
    void ReturnFalse()
    {
        band_bakuhatsu = false;
    }
}