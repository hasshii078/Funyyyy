using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganAttack : MonoBehaviour
{
    public GameObject bach;
    public int O_Attacking;
    //int count;//BachAttacksから持ってくるcountを取得するための変数

    // Start is called before the first frame update
    void Start()
    {
        /*BachAttacksにある値を持ってくる
        BachAttacks code;
        bach = GameObject.Find("Bach");
        code = bach.GetComponent<BachAttacks>();
        count = code.count;*/
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.8f, 0);
    }
}
