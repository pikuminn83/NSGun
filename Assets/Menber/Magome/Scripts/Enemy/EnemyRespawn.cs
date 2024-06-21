using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    //Mob�̃��X�|�[���n�_

    public List<GameObject> MobRespwan = new List<GameObject>();
    public Transform MobPos1;
    public Transform MobPos2;
    //Boss�̃��X�|�[���n�_
    public List<GameObject> BossRespwan = new List<GameObject>();

    public Transform BossPos1;
    public Transform BossPos2;

    float MaxX, Minx, MaxY, Miny;
    float BossMaxX, BossMinx, BossMaxY, BossMiny;

    float MobTime;
    public float MobgenerateTime = 0;

    float BossTime;

    public int BossgenerateTime = 0;

    bool BossLive = false;
    // Start is called before the first frame update
    void Start()
    {
        MaxX = Mathf.Max(MobPos1.transform.position.x, MobPos2.transform.position.x);
        Minx = Mathf.Min(MobPos1.transform.position.x, MobPos2.transform.position.x);
        MaxY = Mathf.Max(MobPos1.transform.position.y, MobPos2.transform.position.y);
        Miny = Mathf.Min(MobPos1.transform.position.y, MobPos2.transform.position.y);

        BossMaxX = Mathf.Max(BossPos1.transform.position.x, BossPos2.transform.position.x);
        BossMinx = Mathf.Min(BossPos1.transform.position.x, BossPos2.transform.position.x);
        BossMaxY = Mathf.Max(BossPos1.transform.position.y, BossPos2.transform.position.y);
        BossMiny = Mathf.Min(BossPos1.transform.position.y, BossPos2.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {

        MobTime += Time.deltaTime;


        if (MobTime > MobgenerateTime)
        {
            MobTime = 0;
            int Mobindex = Random.Range(0, MobRespwan.Count);
            float MobPosX = Random.Range(MaxX, Minx);
            float MobPosY = Random.Range(MaxY, Miny);

            Instantiate(MobRespwan[Mobindex], new Vector3(MobPosX, MobPosY, 0), Quaternion.identity);
        }
        BossTime += Time.deltaTime;
        if (BossTime > BossgenerateTime && BossLive == false)
        {
            float BossPosX = Random.Range(BossMaxX, BossMinx);
            float BossPosY = Random.Range(BossMaxY, BossMiny);

            Instantiate(BossRespwan[0], new Vector3(BossPosX, BossPosY, 0), Quaternion.identity);
            BossLive = true;
        }
    }

}
