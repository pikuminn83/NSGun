using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using UnityEngine.UI;

public class SkillChoose : MonoBehaviour
{

    int skillnum = 0;
    public Image gage;


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
            if (gage.fillAmount >= 0.3f&&skillnum%3==0)
            {
                Debug.Log("MagLiquid”­“®");
                gage.fillAmount -= 0.3f;
            }
            if (gage.fillAmount >= 0.3f)
            {
                if (skillnum % 3 == 1 || skillnum % 3 == -2)

                { Debug.Log("RailGun”­“®");
                    gage.fillAmount -= 0.3f;
                } 
            }
            if (gage.fillAmount >= 0.3f)
            {
                if (skillnum % 3 == 2 || skillnum % 3 == -1)
                {
                    Debug.Log("UniqueMagnet”­“®");
                    gage.fillAmount -= 0.3f;
                }
            }
        }

    }


    // ‘I‘ð’†‚ÌƒXƒLƒ‹


    private void Update()
    {


        if (skillnum % 3 == 0)
        {
            Debug.Log("Skill [MagLiquid] Selected!");
        }

        if (skillnum % 3 == 1||skillnum%3 ==-2)
        {
            Debug.Log("Skill [RailGun] Selected!");
        }

        if (skillnum % 3 == 2 || skillnum %3 ==-1)
        {
            Debug.Log("Skill [UniqueMagnet] Selected!");
        }
        Debug.Log(skillnum%3);
        
        
    }

    


}
