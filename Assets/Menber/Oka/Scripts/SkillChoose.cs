using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SkillChoose : MonoBehaviour
{

    public int skillnum = 0;
    public Image gage;
    [SerializeField] public float cooltime_a = 15.0f;        //��ڂ̃X�L���̃N�[���^�C��
    [SerializeField] public float cooltime_b = 20.0f;        //  ��ڂ̃X�L���̃N�[���^�C��
    [SerializeField] public float cooltime_c = 10.0f;        //  �O�ڂ̃X�L���̃N�[���^�C��
    private float AllSkillcooltime = 50;                      //�@�X�L���͕��������Ɏg�p�ł��Ȃ��̂ł���𐧌䂷�鎞�Ԃ����ۂɌv������ϐ�
    Rigidbody2D playerrb2;                                    //�@Player�̕������Z�𑀍삷�邽��
    Transform playertf;                                       //�@Player�̍��W�A��]�Ȃǂ𑀍삷�邽��
    Player player;                                            //�@Player�X�N���v�g�Ɋ����邽��
    Vector3 bulletpoint;                                      //
    SpriteRenderer playercolor;                               //�@�X�L�����g�����Ƃ��Ƀv���C���[�̐F��ύX���邽��
    public bool MagLiquid;       �@
    float MLtime;                                             //�@�������̂̌��ʎ��ԗp
    public float cooltime_A ;                             
    public float cooltime_B ;�@�@�@�@�@�@�@�@�@�@�@�@�@�@ //  �N�[���^�C�������ۂɌv������ϐ�����
    public float cooltime_C ;
    public bool mgliqOn = false;



    // Start is called before the first frame update
    void Start()
    {
        gage.GetComponent<MagneticGage>();
        GameObject p = GameObject.Find("Player");
        playerrb2 = p.GetComponent<Rigidbody2D>();
        playertf = p.GetComponent<Transform>();
        player = p.GetComponent<Player>();
        playercolor = p.GetComponent<SpriteRenderer>();
        cooltime_A = cooltime_a;
        cooltime_B = cooltime_b;
        cooltime_C = cooltime_c;
        

    }

    // Update is called once per frame
    
    public void Right(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            skillnum++;
        }
    }
    public void Left(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            skillnum--;
        }
    }
   
    public void Use(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            if (skillnum % 3 == 0 && cooltime_A >= cooltime_a && AllSkillcooltime >= 50)
            {
                Debug.Log("MagLiquid����");
                MagLiquid = true;
                cooltime_A = 0;
                MLtime = 0;
                AllSkillcooltime = 50 - 5;
                mgliqOn = true;
            }
            if ((skillnum % 3 == 1 || skillnum % 3 == -2) && cooltime_B >= cooltime_b && AllSkillcooltime >= 50)
            {
                
                { 
                    Debug.Log("RailGun����");
                    playerrb2.velocity = Vector3.zero;
                    playerrb2.gravityScale = 0.0f;
                    player.Railgun();
                    Invoke("Delay", 1);
                    cooltime_B = 0;
                    AllSkillcooltime = 50 - 1;
                }
            } 
            if ((skillnum % 3 == 2 || skillnum % 3 == -1) && cooltime_C >= cooltime_c && AllSkillcooltime >= 50)
            {
                Debug.Log("UniqueMagnet����");
                player.Uniquemagnet();
                cooltime_C = 0;
                AllSkillcooltime = 50 - 5;
            }
            
        }

    }
    public void Delay()
    {
        Vector2 pos = playertf.position;
        if (pos.y > -0.75)
        {
            playerrb2.gravityScale = -3.0f;
        }
        if (pos.y < -0.75)
        {
            playerrb2.gravityScale = 3.0f;
        }
    }

    private void Update()
    {

        cooltime_A += Time.deltaTime;
        cooltime_B += Time.deltaTime;
        cooltime_C += Time.deltaTime;
        AllSkillcooltime += Time.deltaTime;
        if (MagLiquid)
        {
            
            MLtime += Time.deltaTime;

            if( MLtime <= 5)
            {
                playercolor.color = Color.gray;
            }
            else
            {
                MagLiquid = false;
                playercolor.color = Color.white;
                mgliqOn = false;
            }
        }

        
    }

    

 

}
