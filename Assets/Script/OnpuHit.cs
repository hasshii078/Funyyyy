using UnityEngine;
using System.Collections;

public class OnpuHit : MonoBehaviour
{
	//code.lr��������ϐ�Lr Start���ł̏���������FixedUpdate�̎��s�ɊԂɍ��킸�G���[���o��̂ł����Ő錾����
	private bool Lr;

    void Start()
	{
        //SyuzinkouController����p�u���b�N�ϐ�lr�������Ă���
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
		//�g���L���̌��������ɔ��˂����
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