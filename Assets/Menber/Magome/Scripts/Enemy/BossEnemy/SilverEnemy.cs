using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverEnemy : MonoBehaviour
{
    public GameObject Tama;
    private float Timer;

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
    //OnDestroyは自分が消えたことを検知する
    private void OnDestroy()
    {
        EnemyRespawn.instance.BossNotLive();
    }
}
