using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGlassMove : MonoBehaviour
{
    Vector3 _EnemyMove;
    public float Speed;
    private bool Wallhit = false;
    // Update is called once per frame
    void Update()
    {
        if(Wallhit == false)
        {
            // 移動速度を保持
            _EnemyMove = new Vector3(Speed, Speed, 0);
            // オブジェクト移動
            this.transform.position -= _EnemyMove * Time.deltaTime;
        }
        if(Wallhit == true)
        {
            // 移動速度を保持
            _EnemyMove = new Vector3(Speed, -Speed, 0);
            // オブジェクト移動
            this.transform.position -= _EnemyMove * Time.deltaTime;
        }
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.CompareTag("WallTop"))
        {
            Wallhit = false;
        }
        else
        {
            Wallhit = true;
        }
    }
}
