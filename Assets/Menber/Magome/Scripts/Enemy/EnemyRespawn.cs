using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    //Mob�̐�������I�u�W�F�N�g���X�g
    public List<GameObject> MobObj = new List<GameObject>();
    //Mob�̃X�|�[���n�_
    public Transform MobPos1;
    public Transform MobPos2;
    //Turret�̐�������I�u�W�F�N�g
    public List<GameObject> TurretObj = new List<GameObject>();
    public GameObject TurretPosTop;
    public GameObject TurretPosUnder;
    //Boss�̐�������I�u�W�F�N�g
    public List<GameObject> BossObj = new List<GameObject>();
    //Boss�X�|�[���n�_
    public GameObject BossRespwan;
    float MaxX, Minx, MaxY, Miny;
    //Mob��p��Timer�ϐ�
    float MobTime;
�@�@//Mob�̐������鎞��
    public float MobgenerateTime = 0;
    //Turret��p��Timer�ϐ�
    float TurretTime;
    //Turret�̐������鎞��
    public float TurregenerateTime = 0;
    //Turret�̃����_�������ϐ�
    int TurretRandom = 0;
    //Boss��p��Timer�ϐ�
    float BossTime;
    //Boss�̐������鎞��
    public int CopperBossgenerateTime = 0;
    public int GoldBossgenerateTime = 0;
    //�{�X���X�e�[�W�ɂ��邩�̊m�F
    private bool BossLive = false;
    // �{�X�̏o�Ă�����
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
        //Mob�̃X�|�[���n�_�����߂�ׂɍŏ��l�ƍő�l���Ƃ�
        MaxX = Mathf.Max(MobPos1.transform.position.x, MobPos2.transform.position.x);
        Minx = Mathf.Min(MobPos1.transform.position.x, MobPos2.transform.position.x);
        MaxY = Mathf.Max(MobPos1.transform.position.y, MobPos2.transform.position.y);
        Miny = Mathf.Min(MobPos1.transform.position.y, MobPos2.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {

        MobTime += Time.deltaTime;

        if (MobTime > MobgenerateTime && BossLive ==false)
        {
            int Mobindex = Random.Range(0, MobObj.Count);
            float MobPosX = Random.Range(MaxX, Minx);
            float MobPosY = Random.Range(MaxY, Miny);

            Instantiate(MobObj[Mobindex], new Vector3(MobPosX, MobPosY, 0), Quaternion.identity);
            MobTime = 0;
        }
        TurretTime += Time.deltaTime;
        if (TurretTime>TurregenerateTime&&BossLive ==false)
        {
            TurretRandom = Random.Range(0,2);
            switch(TurretRandom)
            { 
                case 0:
                    Instantiate(TurretObj[0],TurretPosTop.transform.position,Quaternion.identity);
                    break;
                case 1:

                    Instantiate(TurretObj[0], TurretPosUnder.transform.position,Quaternion.Euler(0,0,180));
                    break;
            }
            TurretTime = 0;
                
        }
        BossTime += Time.deltaTime;
        switch (BossAppearCount)
        {
            case 0:
                if (BossTime > CopperBossgenerateTime&&BossAppearCount==0)
                {

                    Instantiate(BossObj[0], BossRespwan.transform.position, Quaternion.identity);
                    BossAppearCount = 1;
                    BossLive = true;
                }
                break;
            case 1:
                if (BossTime > GoldBossgenerateTime && BossAppearCount == 1)
                {

                    Instantiate(BossObj[1], BossRespwan.transform.position, Quaternion.identity);
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
