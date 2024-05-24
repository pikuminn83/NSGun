using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using UnityEngine.UI;

public class SkillChoose : MonoBehaviour
{

    public int skillnum = 0;
    public Image gage;
    public float cooltime_a = 15.0f;
    public float cooltime_b = 20.0f;
    public float cooltime_c = 10.0f;
    Rigidbody2D playerrb2;
    Transform playertf;
    


    // Start is called before the first frame update
    void Start()
    {
        gage.GetComponent<MagneticGage>();
        GameObject p = GameObject.Find("Player");
        playerrb2 = p.GetComponent<Rigidbody2D>();
        playertf = p.GetComponent<Transform>();
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
            if (skillnum%3==0&&(int)cooltime_a>=15)
            {
                Debug.Log("MagLiquid”­“®");
                
                cooltime_a = 0;
            }
            if ((skillnum % 3 == 1 || skillnum % 3 == -2) && (int)cooltime_b >= 20)
            {
                Debug.Log("RailGun”­“®");
                playerrb2.gravityScale = 0.0f;
                Invoke("Delay", 3);
                cooltime_b = 0;
            } 
            if ((skillnum % 3 == 2 || skillnum % 3 == -1) && (int)cooltime_c >= 10)
            {
                Debug.Log("UniqueMagnet”­“®");
                cooltime_c = 0;
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


    // ‘I‘ð’†‚ÌƒXƒLƒ‹


    private void Update()
    {

        cooltime_a += Time.deltaTime;
        cooltime_b += Time.deltaTime;
        cooltime_c += Time.deltaTime;
        
        
    }

    


}
