using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadein : MonoBehaviour
{

    [SerializeField] Image fade;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame


    void Update()
    {


        fade.color -= new Color(0.0f, 0.0f, 0.0f, 0.004f);

    }


}

