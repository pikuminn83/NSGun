using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Outline1 : MonoBehaviour
{
    [SerializeField] private Image image;
    SkillChoose skill;
    // Start is called before the first frame update
    void Start()
    {
        GameObject skillmanager = GameObject.Find("SkillManager");
        skill = skillmanager.GetComponent<SkillChoose>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (skill.skillnum % 3 == 0)
        {
            image.color = Color.green;
        }
        else
        {
            image.color = Color.white;
        }
    }
}
