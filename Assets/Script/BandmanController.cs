using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //LoadSceneを使うために必要

public class BandmanController : MonoBehaviour
{
    public GameObject breakEffect; //倒したときのエフェクト

    //public AudioClip bakuhatsu; //主人公が音符投げたら鳴る効果音
    //AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

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

    

}
