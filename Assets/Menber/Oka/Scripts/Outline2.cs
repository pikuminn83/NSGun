using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Outline2 : MonoBehaviour
{
    SkillChoose skill;
    [SerializeField] private Image image;
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
        if (skill.skillnum % 3 == 1 || skill.skillnum % 3 == -2)
        {
            image.color = Color.green;
        }
        else
        {
            image.color = Color.white;
        }
    }
}
