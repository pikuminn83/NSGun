using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    //Mobのリスポーン地点
    public List<GameObject> RespwanMob = new List<GameObject>();
    public Transform MobPos1;
    public Transform MobPos2;
    //Bossのリスポーン地点
    public List<GameObject> RespwanBoss = new List<GameObject>();
    public Transform BossPos1;
    public Transform BossPos2;

    float MaxX, Minx, MaxY, Miny;

    float frame;
    public float generateFrame = 0;
    // Start is called before the first frame update
    void Start()
    {
        MaxX = Mathf.Max(MobPos1.transform.position.x, MobPos2.transform.position.x);
        Minx = Mathf.Min(MobPos1.transform.position.x, MobPos2.transform.position.x);
        MaxY = Mathf.Max(MobPos1.transform.position.y, MobPos2.transform.position.y);
        Miny = Mathf.Min(MobPos1.transform.position.y, MobPos2.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        ++frame;

        if (frame > generateFrame)
        {
            frame = 0;
            int index = Random.Range(0, RespwanMob.Count);
            float PosX = Random.Range(MaxX, Minx);
            float PosY = Random.Range(MaxY, Miny);

            Instantiate(RespwanMob[index], new Vector3(PosX, PosY, 0), Quaternion.identity);
        }
        
    
    }
}
