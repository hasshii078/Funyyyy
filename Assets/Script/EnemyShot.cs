using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3.0f;                   // 移動値
    [SerializeField] Vector3 moveVec = new Vector3(-1, 0, 0);  // 移動方向

    void Update()
    {
        float add_move = moveSpeed * Time.deltaTime;
        transform.Translate(moveVec * add_move);
    }

    public void SetMoveSpeed(float _speed)
    {
        moveSpeed = _speed;
    }

    public void SetMoveVec(Vector3 _vec)
    {
        // 音符の発射範囲を狭めるために、移動ベクトルの大きさを調整
        float maxDistance = 2.0f; // 最大距離を設定（任意の値）
        Vector3 direction = _vec.normalized;
        moveVec = direction * Mathf.Min(maxDistance, direction.magnitude);
    }
}