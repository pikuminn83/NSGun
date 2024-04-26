using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MagneticGage : MonoBehaviour
{

    Image gage;
    public bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        gage = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        if (flag == true)
        {

            float a = Time.deltaTime;

            gage.fillAmount += a/100;
        }
        
    }
}
