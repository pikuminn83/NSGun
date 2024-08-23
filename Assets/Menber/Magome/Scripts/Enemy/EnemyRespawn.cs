using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public bool ModStop = false;
    public bool TurretStop = false;
    public bool BossStop = false;
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
    //Turret�̐����ʒu�@�V��Ȃ�0�@�n�ʂȂ�1
    int TurretGenerationPos = 0;
    //Boss��p��Timer�ϐ�
    float BossTime;
    //Boss�̐������鎞��
    public int FirstBossgenerateTime = 0;
    public int SecondBossgenerateTime = 0;
    public int ThirdBossgenerateTime = 0;
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
                    Instantiate(TurretObj[0],TurretPosTop.transform.position,Quaternion.identity);
                    TurretGenerationPos = 1;
                    break;
                case 1:

                    Instantiate(TurretObj[0], TurretPosUnder.transform.position,Quaternion.Euler(0,0,180));
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
