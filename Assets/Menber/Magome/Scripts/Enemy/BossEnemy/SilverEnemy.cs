using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverEnemy : MonoBehaviour
{
    public GameObject Tama;
    private float Timer; 
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer > 3 )
        {
          Instantiate(Tama,this.transform.position,Quaternion.identity);
           Timer = 0;
        }
    }
    //OnDestroy‚Í©•ª‚ªÁ‚¦‚½‚±‚Æ‚ğŒŸ’m‚·‚é
    private void OnDestroy()
    {
        EnemyRespawn.instance.BossNotLive();
    }
}
