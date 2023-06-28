using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    public GameObject bach;
    GameObject player;
    Transform playerTransform;//��l���̍��W�Ȃ�
    Transform laserpoint;
    //private float speed = 0.3f;//MoveTowards���g���ꍇ�ɕK�v

    // Start is called before the first frame update
    void Start()
    {
        if (StageSelectButton.stage == 0)
        {
            //BachAttacks�ɂ���l�������Ă���
            BachAttacks code;
            bach = GameObject.Find("Bach");
            code = bach.GetComponent<BachAttacks>();
            player = code.player;
            laserpoint = code.laserpoint;
            playerTransform = player.transform;//��l���̍��W���擾
        }
        else if (StageSelectButton.stage == 1)
        {
            BachAttackHard code;
            bach = GameObject.Find("Bach");
            code = bach.GetComponent<BachAttackHard>();
            player = code.player;
            laserpoint = code.laserpoint;
            playerTransform = player.transform;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (laserpoint.position.x-bach.transform.position.x > 0)
        {
            //this.GetComponent<Rigidbody2D>().velocity = new Vector2(20, 0);
            transform.Translate(0.5f, 0, 0);
            transform.localScale = new Vector3(3,3,1);
        }
        else
        {
            transform.Translate(-0.5f, 0, 0);
            transform.localScale = new Vector3(-3, 3, 1);
        }
        //laserpoint.position = playerTransform.position + (playerTransform.position - transform.position);
        
    }
}
