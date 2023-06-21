using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganAttack : MonoBehaviour
{
    public GameObject bach;
    public int O_Attacking;
    //int count;//BachAttacks‚©‚ç‚Á‚Ä‚­‚écount‚ğæ“¾‚·‚é‚½‚ß‚Ì•Ï”

    // Start is called before the first frame update
    void Start()
    {
        /*BachAttacks‚É‚ ‚é’l‚ğ‚Á‚Ä‚­‚é
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
