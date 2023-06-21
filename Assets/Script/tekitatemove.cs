using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tekitatemove : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("画面外でも行動する")] public bool nonVisibleAct;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private bool isInScreen = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sr.isVisible || nonVisibleAct)
        {
           
            if (!isInScreen)
            {
                isInScreen = true;
                rb.velocity = new Vector2(0, speed);
            }
        }
        else
        {
            if (isInScreen)
            {
                isInScreen = false;
                rb.Sleep();
            }
            rb.Sleep();
        }
    }
}
