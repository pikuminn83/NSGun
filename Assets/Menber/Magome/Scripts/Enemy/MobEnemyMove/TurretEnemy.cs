using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : MonoBehaviour
{
    private Vector2 TurretEnemyVec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TurretEnemyVec = this.gameObject.transform.position;
        TurretEnemyVec.x += 2;
    }
}
