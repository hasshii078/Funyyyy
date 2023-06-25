using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public AudioClip bakuhatsu; //”š”­‰¹
    AudioSource audioSource;
    // Start is called before the first frame update

    GameObject player;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        this.player = GameObject.Find("toonkigou");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.player.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y, transform.position.z);
        if (OnpuHit.band_bakuhatsu == true)
        {
            audioSource.PlayOneShot(bakuhatsu);
        }
    }

}
