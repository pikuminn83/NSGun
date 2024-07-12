using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : MonoBehaviour
{
    private Vector3 TurretEnemyVec;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ˆÚ“®‘¬“x‚ğ•Û
        TurretEnemyVec = new Vector3(Speed, 0,0);
        this.transform.position -= TurretEnemyVec * Time.deltaTime;
    }
}
