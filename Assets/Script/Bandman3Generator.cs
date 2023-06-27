using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandman3Generator : MonoBehaviour
{
    //敵プレハブ
    public GameObject enemyPrefab;
    //時間間隔の最小値
    public float minTime = 2f;
    //時間間隔の最大値
    public float maxTime = 5f;
    //X座標の最小値
    public float xMinPosition = -10f;
    //X座標の最大値
    public float xMaxPosition = 10f;
    //Y座標の最小値
    public float yMinPosition = 0f;
    //Y座標の最大値
    public float yMaxPosition = 10f;
    //Z座標の最小値
    public float zMinPosition = 10f;
    //Z座標の最大値
    public float zMaxPosition = 20f;
    //敵生成時間間隔
    private float interval;
    //経過時間
    private float time = 0f;

    //X座標の最小値
    public float xMinPosition1 = -10f;
    //X座標の最大値
    public float xMaxPosition1 = 10f;
    //Y座標の最小値
    public float yMinPosition1 = 0f;
    //Y座標の最大値
    public float yMaxPosition1 = 10f;
    //Z座標の最小値
    public float zMinPosition1 = 10f;
    //Z座標の最大値
    public float zMaxPosition1 = 20f;

    // Start is called before the first frame update
    void Start()
    {
        //時間間隔を決定する
        interval = GetRandomTime();  
    }

    // Update is called once per frame
    void Update()
    {
        //時間計測
        time += Time.deltaTime;

        //経過時間が生成時間になったとき(生成時間より大きくなったとき)
        if (time > interval)
        {
            //enemyをインスタンス化する(生成する)
            GameObject enemy = Instantiate(enemyPrefab);
            GameObject enemy1 = Instantiate(enemyPrefab);
            //生成した敵の位置をランダムに設定する
            enemy.transform.position = GetRandomPosition();
            enemy1.transform.position = GetRandomPosition1();
            //経過時間を初期化して再度時間計測を始める
            time = 0f;
            //次に発生する時間間隔を決定する
            interval = GetRandomTime();
            Destroy(enemy, 5.0f);
            Destroy(enemy1, 5.0f);
        }
    }

    //ランダムな時間を生成する関数
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }

    //ランダムな位置を生成する関数
    private Vector3 GetRandomPosition()
    {
        //それぞれの座標をランダムに生成する
        float x = Random.Range(xMinPosition, xMaxPosition);
        float y = Random.Range(yMinPosition, yMaxPosition);
        float z = Random.Range(zMinPosition, zMaxPosition);

        //Vector3型のPositionを返す
        return new Vector3(x, y, z);      
    }

    private Vector3 GetRandomPosition1()
    {
        float x1 = Random.Range(xMinPosition1, xMaxPosition1);
        float y1 = Random.Range(yMinPosition1, yMaxPosition1);
        float z1 = Random.Range(zMinPosition1, zMaxPosition1);
        return new Vector3(x1, y1, z1);
    }
}