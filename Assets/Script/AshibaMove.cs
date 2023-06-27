using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AshibaMove : MonoBehaviour
{
    //�ϐ���`
    Rigidbody2D rb;
    SurfaceEffector2D surfaceEffector;
    Vector2 DefaultPos;
    Vector2 PrevPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DefaultPos = transform.position;
        surfaceEffector = GetComponent<SurfaceEffector2D>();
    }

    void FixedUpdate()
    {
        PrevPos = rb.position;

        // Y���W�̂݉��ړ��@Mathf.PingPong�̐��l�����ύX�ňړ��������ς��
        Vector2 pos = new Vector2(DefaultPos.x, DefaultPos.y + Mathf.PingPong(Time.time, 5));
        rb.MovePosition(pos);

        // ���x���t�Z����
        Vector2 velocity = (pos - PrevPos) / Time.deltaTime * 50;

        // ���x��X������ SurfaceEffector2D �ɓK�p
        surfaceEffector.speed = velocity.x;
    }
}