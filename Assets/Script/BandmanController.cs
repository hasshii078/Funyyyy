using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //LoadSceneを使うために必要

public class BandmanController : MonoBehaviour
{
    public GameObject breakEffect; //倒したときのエフェクト
    enum ShotType
    {
        NONE = 0,
        AIM,            // プレイヤーを狙う
        THREE_WAY,      // ３方向
    }

    [System.Serializable]
    struct ShotData
    {
        public int frame;
        public ShotType type;
        public EnemyShot bullet;
    }

    // ショットデータ
    [SerializeField] ShotData shotData = new ShotData { frame = 60, type = ShotType.NONE, bullet = null };

    GameObject playerObj = null;    // プレイヤーオブジェクト
    int shotFrame = 0;              // フレーム


    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーオブジェクトを取得する
        switch (shotData.type)
        {
            case ShotType.AIM:
                playerObj = GameObject.Find("toonkigou");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Shot();
    }
    public void OnpuHit1()
    {
        Destroy(this.gameObject);
        //audioSource.PlayOneShot(bakuhatsu);
        GenerateEffect();　//エフェクト発生
    }

    void GenerateEffect()
    {
        //エフェクト発生
        GameObject effect = Instantiate(breakEffect) as GameObject;
        //エフェクト発生する場所を決定
        effect.transform.position = gameObject.transform.position;
    }
    void Shot()
    {
        ++shotFrame;
        if (shotFrame > shotData.frame)
        {
            switch (shotData.type)
            {
                // プレイヤーを狙う
                case ShotType.AIM:
                    {
                        if (playerObj == null) { break; }
                        EnemyShot bullet = (EnemyShot)Instantiate(
                            shotData.bullet,
                            transform.position,
                            Quaternion.identity
                        );
                        bullet.SetMoveVec(playerObj.transform.position - transform.position);
                        Destroy(bullet.gameObject,7.0f);
                    }
                    break;

                // ３方向
                case ShotType.THREE_WAY:
                    {
                        EnemyShot bullet = (EnemyShot)Instantiate(
                            shotData.bullet,
                            transform.position,
                            Quaternion.identity
                        );
                        bullet = (EnemyShot)Instantiate(shotData.bullet, transform.position, Quaternion.identity);
                        bullet.SetMoveVec(Quaternion.AngleAxis(15, new Vector3(0, 0, 1)) * new Vector3(-1, 0, 0));
                        bullet = (EnemyShot)Instantiate(shotData.bullet, transform.position, Quaternion.identity);
                        bullet.SetMoveVec(Quaternion.AngleAxis(-15, new Vector3(0, 0, 1)) * new Vector3(-1, 0, 0));
                        Destroy(bullet.gameObject, 7.0f);
                    }
                    break;
            }

            shotFrame = 0;
        }
       
    }
}
