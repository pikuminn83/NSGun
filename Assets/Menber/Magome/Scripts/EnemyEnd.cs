using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEnd : MonoBehaviour
{
    public bool OutsideCamera=false;

    public void OnCollisionEnter2D(Collision2D HitEnemy)
    {
        if(HitEnemy.gameObject.CompareTag("Enemy") || HitEnemy.gameObject.CompareTag("EnemyBullet"))
        {
            OutsideCamera = true;
            Destroy(HitEnemy.gameObject);
        }
    }
    //�W�c���܂Ƃ߂Ă���I�u�W�F�N�g������
    public void OnTriggerEnter2D(Collider2D TrigerEnemy)
    {
        if(TrigerEnemy.gameObject.CompareTag("Enemy"))
        {
            Destroy(TrigerEnemy.gameObject);
        }
    }
}
