using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : MonoBehaviour
{
    private Vector3 TurretEnemyVec;
    public float Speed;
    private GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // à⁄ìÆë¨ìxÇï€éù
        TurretEnemyVec = new Vector3(Speed, 0,0);
        this.transform.position -= TurretEnemyVec * Time.deltaTime;

        Vector3 diff = (Target.gameObject.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);
    }
}
