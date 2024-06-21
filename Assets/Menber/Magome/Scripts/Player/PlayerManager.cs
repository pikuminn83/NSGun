using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    SkillChoose skill;
    Image skill1;
    // Start is called before the first frame update
    void Start()
    {
        GameObject skillmanager = GameObject.Find("SkillManager");
        skill = skillmanager.GetComponent<SkillChoose>();
        skill1 = GetComponent<Image>();
    }


    // Update is called once per frame
    void Update()
    {
        
        skill1.fillAmount = skill.cooltime_a / 15;
    }
}
