using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class BachAttacks : MonoBehaviour
{

    public GameObject bach;//バッハ格納用
    public Sprite Bachbright;//バッハ攻撃中の画像
    public Sprite BachNormal;//バッハ通常画像
    SpriteRenderer BachSprite;//バッハの画像の種類を変えるため用意

    public GameObject player;//主人公格納
    Transform playerTransform;//主人公の座標など

    public GameObject laser;//レーザー
    private GameObject laserobj;
    public Transform laserpoint;//レーザーの発射向きを特定するために、バッハ移動完了時点での主人公の座標を取得する

    public GameObject organ;//パイプオルガン
    private GameObject organobj;
    public int count=0;//パイプを落とした回数を数える

    public float speed = 0.2f;//バッハ移動スピード
    public int AttackType=0;//バッハがどの攻撃をするか決める変数
    //１：画面端から光線　２：パイプオルガン投下

    private int[,] posi=new int[2,2] { { -10, 10 }, { 10, 0 } };//ビーム発射時のx,y座標候補。{{x1,x2},{y1,y2}}。
    
    Vector3 movePosition;//ビーム発射時のバッハが行く場所

    public int Attacking = 0;//バッハが攻撃前か攻撃中か攻撃後か(0,1,2)

    // Start is called before the first frame update
    void Start()
    {
        BachSprite = bach.GetComponent<SpriteRenderer>();//バッハのスプライトを取得
        
        playerTransform = player.transform;//主人公の座標を取得
        movePosition = new Vector3(posi[0, Random.Range(0, 2)], posi[1, Random.Range(0, 2)], 0);//ビーム時の移動場所を予め決める

        laser = Resources.Load<GameObject>("Laser");//ResourcesフォルダからLaserプレハブを読み込む
        organ = Resources.Load<GameObject>("Organ");//ResourcesフォルダからOrganプレハブを読み込む

        laserpoint = laser.transform;//よくわからないがこの一文がないと動かないので消さない

    }

    // Update is called once per frame
    void Update()
    {
        //主人公側を向く
        if (this.bach.transform.position.x < playerTransform.position.x)
        {
            transform.localScale = new Vector3(3, 3, 1);
        }
        else
        {
            transform.localScale = new Vector3(-3, 3, 1);
        }

        //もし攻撃中でないなら新しく攻撃をセット
        if (AttackType == 0)
        {
            movePosition = new Vector3(posi[0, Random.Range(0, 2)], posi[1, Random.Range(0, 2)], 0);//ビーム時の移動場所を予め決める
            AttackType = Random.Range(1, 3);//(n,m)でn以上m未満のランダムな整数
        }
        else if (AttackType == 1) //レーザー攻撃が選ばれた場合
        {
            Attack_1();
        }
        else if (AttackType == 2) 
        {
            Attack_2();
        }
        
    }

    //レーザー攻撃
    void Attack_1() 
    {
        //目的地に移動する
        this.bach.transform.position = Vector3.MoveTowards(bach.transform.position, movePosition, speed);
        if (movePosition == this.bach.transform.position) 
        {
            //まだビーム撃ってない(Attacking==0)なら撃つ
            if (Attacking == 0) 
            {
                Attacking = 1;//状態を攻撃中に設定
                BachSprite.sprite = Bachbright;//バッハを光ってる画像に変える
                laserobj = Instantiate(laser, this.bach.transform.position, Quaternion.identity);//レーザーをオブジェクトにして画面に表示
                laserpoint.position = playerTransform.position;//レーザーの目的地だったが主人公の座標を示すものにしてみる。この時点で座標を取り、ビーム発射中随時主人公の座標を更新しないようにする。
                Invoke("DestroyLaser",2.0f);
            }
        }
        //攻撃終了(AttackType=0にする)
        if (Attacking==2) 
        {
            BachSprite.sprite = BachNormal;//バッハの画像を戻す
            AttackType =0;//攻撃前の状態へ
            Attacking = 0;//状態を攻撃前に設定
        }

    }
    //レーザーの元になる弾が消えるようにする
    void DestroyLaser() 
    {
        Destroy(laserobj);//弾消す
        Attacking = 2;//状態を攻撃終了に設定
    }

    //パイプ投下攻撃
    void Attack_2()
    {
        this.bach.transform.position = Vector3.MoveTowards(bach.transform.position,new Vector3(0,20,0),speed);//バッハ上に移動
        //Attacking = 1;//状態を攻撃中に設定
         
        if (Attacking ==0)
        {
            Attacking = 1;

            Vector3 posi = new Vector3(Random.Range(-10, 10), 20, 0);//パイプが出現する座標
            organobj = Instantiate(organ, posi, Quaternion.identity);//パイプをオブジェクトにして画面に表示
            Invoke("DestroyOrgan", 1.0f);
        }

        //攻撃終了(AttackType=0にする)
        if (Attacking == 2)
        {
            AttackType = 0;//攻撃前の状態へ
            Attacking = 0;//状態を攻撃前に設定
        }
    }
    //パイプが消えるようにする
    void DestroyOrgan()
    {
        Destroy(organobj);//弾消す
        Attacking = 2;
        //count++;
        //Debug.Log(count);
    }
}
