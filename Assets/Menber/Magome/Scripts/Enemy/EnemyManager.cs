using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //敵一体分のスコア
    public int Person_EnemyScore = 0;
    //敵HP
    public int HP = 0;

    public UIManager _uiManager;

    [SerializeField]
    private float explosionRadius; // 爆発半径
    [SerializeField]
    public EnemyManager explosionEnemy;

    void Start()
    {
        GameObject _uiObj = GameObject.Find("Score");
        _uiManager = _uiObj.GetComponent<UIManager>();
    }
    public void OnCollisionEnter2D(Collision2D Hit)
    {
        //Bulletの場合当たったオブジェクトだけを消す
        //自分のスコアをUIManagerにプラスする
        if (Hit.gameObject.CompareTag("Bullet"))
        {
            HP--;
            EnemyScoreAdd();
        }
        if(Hit.gameObject.CompareTag("BulletSpecial"))
        {
           Debug.Log("BulletSpecial");
           BulletSpecial();
        }
        if(Hit.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Hit");
        }

    }
    public void BulletSpecial()
    {
        // 爆風の範囲内のオブジェクトを検出
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D colliderAll in colliders)
        {
            if(colliderAll.gameObject.CompareTag("Enemy"))
            {
                //周りに爆発ダメージ
                //＊GlassRankEnemyPartyはバグで4体までしか倒せない後々検証と修正
                explosionEnemy = colliderAll.gameObject.GetComponent<EnemyManager>();
                explosionEnemy.HP--;
                EnemyScoreAdd();
                Destroy(colliderAll.gameObject);
               // Debug.Log($"検出されたオブジェクト {colliderAll.name}");
            }

        }

    }
    public void EnemyScoreAdd()
    {
        if (HP == 0)
        {
            _uiManager._EnemyScore = Person_EnemyScore;
            _uiManager.SumScore();
            Destroy(this.gameObject);
        }

    }

}
