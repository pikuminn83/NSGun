using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : MonoBehaviour
{
    private Vector3 TurretEnemyVec;
    public float Speed;
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
        // ˆÚ“®‘¬“x‚ð•ÛŽ
        TurretEnemyVec = new Vector3(Speed, 0, 0);
        this.transform.position -= TurretEnemyVec * Time.deltaTime;
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
