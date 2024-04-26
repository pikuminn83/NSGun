using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class SkillChoose : MonoBehaviour
{

    int skillnum = 0;

    // Start is called before the first frame update
    void Start()
    {

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


    // ‘I‘ð’†‚ÌƒXƒLƒ‹
    private SkillFactory.SkillKind selectedSkillKind;

    private void Update()
    {

        
        if (skillnum%3==0)
        {
            Debug.Log("Skill [MagLiquid] Selected!");
            this.selectedSkillKind = SkillFactory.SkillKind.MagLiquid;
        }

        if (skillnum%3==1)
        {
            Debug.Log("Skill [RailGun] Selected!");
            this.selectedSkillKind = SkillFactory.SkillKind.RailGun;
        }

        if (skillnum%3==2)
        {
            Debug.Log("Skill [UniqueMagnet] Selected!");
            this.selectedSkillKind = SkillFactory.SkillKind.UniqueMagnet;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            var skillFactory = new SkillFactory();
            var skill = skillFactory.Create(this.selectedSkillKind);
            skill.Play();
        }
        Debug.Log(skillnum);
    }

    


}
