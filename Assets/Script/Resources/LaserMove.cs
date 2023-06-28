using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    public GameObject bach;
    GameObject player;
    Transform playerTransform;//主人公の座標など
    Transform laserpoint;
    //private float speed = 0.3f;//MoveTowardsを使う場合に必要

    // Start is called before the first frame update
    void Start()
    {
        if (StageSelectButton.stage == 0)
        {
            //BachAttacksにある値を持ってくる
            BachAttacks code;
            bach = GameObject.Find("Bach");
            code = bach.GetComponent<BachAttacks>();
            player = code.player;
            laserpoint = code.laserpoint;
            playerTransform = player.transform;//主人公の座標を取得
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
