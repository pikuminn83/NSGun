using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SkillChoose : MonoBehaviour
{

    public int skillnum = 0;
    public Image gage;
    [SerializeField] public float cooltime_a = 15.0f;        //一つ目のスキルのクールタイム
    [SerializeField] public float cooltime_b = 20.0f;        //  二つ目のスキルのクールタイム
    [SerializeField] public float cooltime_c = 10.0f;        //  三つ目のスキルのクールタイム
    private float AllSkillcooltime = 50;                      //　スキルは複数個同時に使用できないのでそれを制御する時間を実際に計測する変数
    Rigidbody2D playerrb2;                                    //　Playerの物理演算を操作するため
    Transform playertf;                                       //　Playerの座標、回転などを操作するため
    Player player;                                            //　Playerスクリプトに干渉するため
    Vector3 bulletpoint;                                      //
    SpriteRenderer playercolor;                               //　スキルを使ったときにプレイヤーの色を変更するため
    public bool MagLiquid;       　
    float MLtime;                                             //　磁性流体の効果時間用
    public float cooltime_A ;                             
    public float cooltime_B ;　　　　　　　　　　　　　　 //  クールタイムを実際に計測する変数たち
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
                Debug.Log("MagLiquid発動");
                MagLiquid = true;
                cooltime_A = 0;
                MLtime = 0;
                AllSkillcooltime = 50 - 5;
                mgliqOn = true;
            }
            if ((skillnum % 3 == 1 || skillnum % 3 == -2) && cooltime_B >= cooltime_b && AllSkillcooltime >= 50)
            {
                
                { 
                    Debug.Log("RailGun発動");
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
                Debug.Log("UniqueMagnet発動");
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
