using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    //Mobのリスポーン地点
    public List<GameObject> MobObj = new List<GameObject>();
    public Transform MobPos1;
    public Transform MobPos2;
    //Bossのリスポーン地点
    public List<GameObject> BossObj = new List<GameObject>();
    //GoldBossスポーン地点
    public GameObject GoldBossRespwan;

    public Transform BossPos1;
    public Transform BossPos2;

    float MaxX, Minx, MaxY, Miny;
    float BossMaxX, BossMinx, BossMaxY, BossMiny;

    float MobTime;
    public float MobgenerateTime = 0;

    float BossTime;
    public int CopperBossgenerateTime = 0;
    public int GoldBossgenerateTime = 0;
    //ボスがステージにいるかの確認
    private bool BossLive = false;
    // ボスの出てきた回数
    int BossAppearCount = 0;

    public static EnemyRespawn instance;
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
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

        if (MobTime > MobgenerateTime && BossLive ==false)
        {
            MobTime = 0;
            int Mobindex = Random.Range(0, MobObj.Count);
            float MobPosX = Random.Range(MaxX, Minx);
            float MobPosY = Random.Range(MaxY, Miny);

            Instantiate(MobObj[Mobindex], new Vector3(MobPosX, MobPosY, 0), Quaternion.identity);
        }
        BossTime += Time.deltaTime;
        switch (BossAppearCount)
        {
            case 0:
                if (BossTime > CopperBossgenerateTime&&BossAppearCount==0)
                {
                    float BossPosX = Random.Range(BossMaxX, BossMinx);
                    float BossPosY = Random.Range(BossMaxY, BossMiny);

                    Instantiate(BossObj[0], new Vector3(BossPosX, BossPosY, 0), Quaternion.identity);
                    BossAppearCount = 1;
                    BossLive = true;
                }
                break;
            case 1:
                if (BossTime > GoldBossgenerateTime && BossAppearCount == 1)
                {
                    float BossPosX = Random.Range(BossMaxX, BossMinx);
                    float BossPosY = Random.Range(BossMaxY, BossMiny);

                    Instantiate(BossObj[1], GoldBossRespwan.transform.position, Quaternion.identity);
                    BossAppearCount = 2;
                    BossLive = true;
                }
                break;
        }
    }
    public void BossNotLive()
    {
        BossLive = false;
    }
}
