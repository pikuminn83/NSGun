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
    //OnDestroyは自分が消えたことを検知する
    private void OnDestroy()
    {
        EnemyRespawn.instance.BossNotLive();
    }
}
