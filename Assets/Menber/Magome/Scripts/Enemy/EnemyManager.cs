using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //敵一体分のスコア
    public int Person_EnemyScore = 0;
    //敵HP
    public int HP=0;

    public UIManager _uiManager;

    [SerializeField]
    private float explosionRadius; // 爆発半径

    void Start()
    {
        GameObject _uiObj = GameObject.Find("Score");
        _uiManager = _uiObj.GetComponent<UIManager>();
    }
    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D Hit)
    {
        //現在はプレイヤーをBulletにしている
        if (Hit.gameObject.CompareTag("Bullet"))
        {

            EnemyScoreAdd();
        }

    }
    public void BulletSpecial()
    {

    }
    public void EnemyScoreAdd()
    {
        // 爆風の範囲内のオブジェクトを検出
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D collider in colliders)
        {
            //敵を倒した時のポイント加算
            if (collider.gameObject.CompareTag("Enemy"))
            {
                HP--;
                if(HP == 0)
                {
                    _uiManager._EnemyScore = Person_EnemyScore;
                   _uiManager.SumScore();
                   Destroy(this.gameObject);
                }
            }
        }
    }

}
