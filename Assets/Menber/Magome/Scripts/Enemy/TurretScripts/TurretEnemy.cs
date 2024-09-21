using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : MonoBehaviour
{
    private float Timer;
    private GameObject Target;
    public GameObject TurretBullet;
    public GameObject TurretBulletPos;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 diff = (Target.gameObject.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);
        Timer += Time.deltaTime;
        if (Timer > 5)
        {
            Instantiate(TurretBullet, TurretBulletPos.transform.position, Quaternion.identity);
            Timer = 0;
        }
    }
}
