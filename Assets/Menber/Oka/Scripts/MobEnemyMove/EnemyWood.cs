using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWood : MonoBehaviour
{
    Vector3 _EnemyMove;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 移動速度を保持
        _EnemyMove = new Vector3(Speed, 0, 0);
        // オブジェクト移動
        this.transform.position -= _EnemyMove * Time.deltaTime;
    }
}
