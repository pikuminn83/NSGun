using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public bool ModStop = false;
    public bool TurretStop = false;
    public bool BossStop = false;
    //Mobの生成するオブジェクトリスト
    public List<GameObject> MobObj = new List<GameObject>();
    //Mobのスポーン地点
    public Transform MobPos1;
    public Transform MobPos2;
    //Turretの生成するオブジェクト
    public List<GameObject> TurretObj = new List<GameObject>();
    public GameObject TurretPosTop;
    public GameObject TurretPosUnder;
    //Bossの生成するオブジェクト
    public List<GameObject> BossObj = new List<GameObject>();
    //Bossスポーン地点
    public GameObject BossRespwan;
    float MaxX, Minx, MaxY, Miny;
    //Mob専用のTimer変数
    float MobTime;
　　//Mobの生成する時間
    public float MobgenerateTime = 0;
    //Turret専用のTimer変数
    float TurretTime;
    //Turretの生成する時間
    public float TurregenerateTime = 0;
    //Turretの生成位置　天井なら0　地面なら1
    int TurretGenerationPos = 0;
    //Boss専用のTimer変数
    float BossTime;
    //Bossの生成する時間
    public int FirstBossgenerateTime = 0;
    public int SecondBossgenerateTime = 0;
    public int ThirdBossgenerateTime = 0;
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
        //Mobのスポーン地点を決める為に最小値と最大値をとる
        MaxX = Mathf.Max(MobPos1.transform.position.x, MobPos2.transform.position.x);
        Minx = Mathf.Min(MobPos1.transform.position.x, MobPos2.transform.position.x);
        MaxY = Mathf.Max(MobPos1.transform.position.y, MobPos2.transform.position.y);
        Miny = Mathf.Min(MobPos1.transform.position.y, MobPos2.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {

        MobTime += Time.deltaTime;

        if (MobTime > MobgenerateTime && BossLive ==false && ModStop==false)
        {
            int Mobindex = Random.Range(0, MobObj.Count);
            float MobPosX = Random.Range(MaxX, Minx);
            float MobPosY = Random.Range(MaxY, Miny);

            Instantiate(MobObj[Mobindex], new Vector3(MobPosX, MobPosY, 0), Quaternion.identity);
            MobTime = 0;
        }
        TurretTime += Time.deltaTime;
        if (TurretTime>TurregenerateTime&&BossLive ==false && TurretStop == false)
        {
            switch(TurretGenerationPos)
            { 
                case 0:
                    Instantiate(TurretObj[0],TurretPosTop.transform.position,Quaternion.Euler(0,0,180));
                    TurretGenerationPos = 1;
                    break;
                case 1:

                    Instantiate(TurretObj[0], TurretPosUnder.transform.position,Quaternion.identity);
                    TurretGenerationPos = 0;
                    break;
            }
            TurretTime = 0;
                
        }
        BossTime += Time.deltaTime;
        switch (BossAppearCount)
        {
            case 0:
                if (BossTime > FirstBossgenerateTime&&BossAppearCount== 0 && BossStop == false)
                {

                    Instantiate(BossObj[0], BossRespwan.transform.position, Quaternion.identity);
                    BossAppearCount = 1;
                    BossLive = true;
                }
                break;
            case 1:
                if (BossTime > SecondBossgenerateTime && BossAppearCount == 1)
                {

                    Instantiate(BossObj[1], BossRespwan.transform.position, Quaternion.identity);
                    BossAppearCount = 2;
                    BossLive = true;
                }
                break;
            case 2:
                if (BossTime > ThirdBossgenerateTime && BossAppearCount == 2)
                {

                    Instantiate(BossObj[2], BossRespwan.transform.position, Quaternion.identity);
                    BossAppearCount = 3;
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
