using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //LoadSceneを使うために必要

public class BandmanController : MonoBehaviour
{
    public GameObject breakEffect; //倒したときのエフェクト

    public void OnpuHit1()
    {
        Destroy(this.gameObject);
        GenerateEffect();　//エフェクト発生
    }

    void GenerateEffect()
    {
        //エフェクト発生
        GameObject effect = Instantiate(breakEffect) as GameObject;
        //エフェクト発生する場所を決定
        effect.transform.position = gameObject.transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
