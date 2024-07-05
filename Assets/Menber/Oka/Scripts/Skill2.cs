using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Skill2 : MonoBehaviour
{
    SkillChoose skill;
    Image skill2;
    // Start is called before the first frame update
    void Start()
    {
        GameObject skillmanager = GameObject.Find("SkillManager");
        skill = skillmanager.GetComponent<SkillChoose>();
        skill2 = GetComponent<Image>();
    }


    // Update is called once per frame
    void Update()
    {
        skill2.fillAmount = skill.cooltime_B / 20;
    }
}
