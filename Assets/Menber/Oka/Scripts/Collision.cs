using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    MagneticGage mg;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Gage = GameObject.Find("MagneticGage");
        mg = Gage.GetComponent<MagneticGage>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        mg.flag = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        mg.flag = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
