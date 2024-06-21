using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverEnemy : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //OnDestroy‚Í©•ª‚ªÁ‚¦‚½‚±‚Æ‚ğŒŸ’m‚·‚é
    private void OnDestroy()
    {
        EnemyRespawn.instance.BossNotLive();
    }
}
