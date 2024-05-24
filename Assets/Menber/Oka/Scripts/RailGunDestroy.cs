using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGunDestroy : MonoBehaviour
{
    float a = 0;
    private void Update()
    {
        a += Time.deltaTime;
        if (a > 3)
        {
            Destroy(this.gameObject);
        }
    }

}
