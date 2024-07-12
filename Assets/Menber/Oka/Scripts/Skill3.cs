using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Skill3 : MonoBehaviour
{
    SkillChoose skill;
    Image skill3;
    // Start is called before the first frame update
    void Start()
    {
        GameObject skillmanager = GameObject.Find("SkillManager");
        skill = skillmanager.GetComponent<SkillChoose>();
        skill3 = GetComponent<Image>();
    }

    
    // Update is called once per frame
    void Update()
    {
        skill3.fillAmount = skill.cooltime_C / 10;
    }
}
