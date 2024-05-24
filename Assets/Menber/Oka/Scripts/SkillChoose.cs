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
    float cooltime_a;
    float cooltime_b;
    float cooltime_c;
    //クールタイム用のフラグ
    public bool flag_a = true;
    public bool flag_b = true;
    public bool flag_c = true;


    // Start is called before the first frame update
    void Start()
    {
        gage.GetComponent<MagneticGage>();
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
                Debug.Log("MagLiquid発動");
                cooltime_a = 0;
            }
            if ((skillnum % 3 == 1 || skillnum % 3 == -2) && (int)cooltime_b >= 20)
            {
                Debug.Log("RailGun発動");
                cooltime_b = 0;
            } 
            if ((skillnum % 3 == 2 || skillnum % 3 == -1) && (int)cooltime_c >= 10)
            {
                Debug.Log("UniqueMagnet発動");
                cooltime_c = 0;
            }
            
        }

    }


    // 選択中のスキル


    private void Update()
    {

        cooltime_a += Time.deltaTime;
        cooltime_b += Time.deltaTime;
        cooltime_c += Time.deltaTime;

        
    }

    


}
