using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //LoadScene���g�����߂ɕK�v

public class BandmanController : MonoBehaviour
{
    public GameObject breakEffect; //�|�����Ƃ��̃G�t�F�N�g

    //public AudioClip bakuhatsu; //��l�������������������ʉ�
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
        GenerateEffect();�@//�G�t�F�N�g����
    }

    void GenerateEffect()
    {
        //�G�t�F�N�g����
        GameObject effect = Instantiate(breakEffect) as GameObject;
        //�G�t�F�N�g��������ꏊ������
        effect.transform.position = gameObject.transform.position;
    }

    

}
