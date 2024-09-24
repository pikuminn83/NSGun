using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverEnemy : MonoBehaviour
{
    public GameObject Tama;
    public GameObject TamaPos;
    private float Timer;

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer > 3 )
        {
          Instantiate(Tama, TamaPos.transform.position,Quaternion.identity);
           Timer = 0;
        }
    }
    //OnDestroy�͎��������������Ƃ����m����
    private void OnDestroy()
    {
        EnemyRespawn.instance.BossNotLive();
    }
}
