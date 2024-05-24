using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill3 : MonoBehaviour
{

    Outline outline;
    // Start is called before the first frame update
    void Start()
    {
        SkillChoose skill;
        GameObject skillmanager = GameObject.Find("SkillManager");
        skill = skillmanager.GetComponent<SkillChoose>();
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
