using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Outline1 : MonoBehaviour
{
    SkillChoose skill;
    Outline outline;
    // Start is called before the first frame update
    void Start()
    {
        GameObject skillmanager = GameObject.Find("SkillManager");
        skill = skillmanager.GetComponent<SkillChoose>();
        outline = this.gameObject.GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if (skill.skillnum % 3 == 0)
        {
            outline.effectColor = Color.blue;
        }
        else
        {
            outline.effectColor = Color.clear;
        }
    }
}
