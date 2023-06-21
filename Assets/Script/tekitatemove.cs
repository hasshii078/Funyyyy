using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tekitatemove : MonoBehaviour
{
    #region//�C���X�y�N�^�[�Őݒ肷��
    [Header("�ړ����x")] public float speed;
    [Header("�d��")] public float gravity;
    [Header("��ʊO�ł��s������")] public bool nonVisibleAct;
    #endregion

    #region//�v���C�x�[�g�ϐ�
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
