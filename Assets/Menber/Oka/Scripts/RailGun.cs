using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGun : MonoBehaviour
{
    float a = 0; //Œø‰ÊŠÔ—p
    private void Update()
    {
        a += Time.deltaTime;
        if (a > 1)     //1•b‚½‚Á‚½‚çŒø‰Ê‚ğI—¹‚·‚é
        {
            Destroy(this.gameObject);
        }
    }

}
