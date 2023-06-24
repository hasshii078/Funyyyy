using UnityEngine;
using System.Collections;

public class OnpuHit : MonoBehaviour
{
	//code.lrを代入する変数Lr Start内での初期化だとFixedUpdateの実行に間に合わずエラーが出るのでここで宣言する
	private bool Lr;

    void Start()
	{
        //SyuzinkouControllerからパブリック変数lrを持ってくる
        GameObject Toonkigou;
        SyuzinkouController code;
        Toonkigou = GameObject.Find("toonkigou");
		code = Toonkigou.GetComponent<SyuzinkouController>();
		Lr = code.lr;
    }

    void OnBecameInvisible()
    {
		Destroy(this.gameObject);
    }
    void FixedUpdate()
	{
		//ト音記号の向く方向に発射される
		if (Lr)
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
			trigger.gameObject.GetComponent<BandmanController>().OnpuHit1();
			Destroy(this.gameObject);
		}
		if (trigger.gameObject.GetComponent<BachMove>())
		{
			trigger.gameObject.GetComponent<BachMove>().OnpuHit1();
			Destroy(this.gameObject);
		}
	}
}