using UnityEngine;
using System.Collections;

public class OnpuHitHard : MonoBehaviour
{
    //code.lr��������ϐ�Lr Start���ł̏���������FixedUpdate�̎��s�ɊԂɍ��킸�G���[���o��̂ł����Ő錾����
    private bool Rr;
    public static bool band_bakuhatsu = false;//�����������ǂ���

    void Start()
    {
        //SyuzinkouController����p�u���b�N�ϐ�lr�������Ă���
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
        //�g���L���̌��������ɔ��˂����
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
            band_bakuhatsu = true;//�����o�����߂̕ϐ�
            trigger.gameObject.GetComponent<BandmanController>().OnpuHit1();
            Destroy(this.gameObject, 0.1f);
            Invoke("ReturnFalse", 0.01f);//����false�ɖ߂�

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