using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D Hit)
    {
        //現在はプレイヤーをBulletにしている
        if (Hit.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.Enemy);
        }
        
    }


}
