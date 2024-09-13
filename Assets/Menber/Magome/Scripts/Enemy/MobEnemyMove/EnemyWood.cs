using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWood : EnemyManager
{
    Vector3 _EnemyMove;
    public float Speed;

    // Update is called once per frame
    void Update()
    {
        // 移動速度を保持
        _EnemyMove = new Vector3(Speed, 0, 0);
        // オブジェクト移動
        this.transform.position -= _EnemyMove * Time.deltaTime;
    }
}
