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
        //BachAttacks�ɂ���l�������Ă���
        BachAttacks code;
        bach = GameObject.Find("Bach");
        code = bach.GetComponent<BachAttacks>();
        player = code.player;
        laserpoint = code.laserpoint;
        playerTransform = player.transform;//��l���̍��W���擾
    }

    // Update is called once per frame
    void Update()
    {
        if (laserpoint.position.x-bach.transform.position.x > 0)
        {
            //this.GetComponent<Rigidbody2D>().velocity = new Vector2(20, 0);
            transform.Translate(0.5f, 0, 0);
        }
        else
        {
            transform.Translate(-0.5f, 0, 0);
        }
        //laserpoint.position = playerTransform.position + (playerTransform.position - transform.position);
        
    }
}
