using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEnd : MonoBehaviour
{
    public bool OutsideCamera=false;

    public void OnCollisionEnter2D(Collision2D HitEnemy)
    {
        if(HitEnemy.gameObject.CompareTag("Enemy"))
        {
            OutsideCamera = true;
            Destroy(HitEnemy.gameObject);
        }
        else
        {
            Destroy(HitEnemy.gameObject);
        }
    }
}
