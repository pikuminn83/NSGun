using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGun : MonoBehaviour
{
    float a = 0; //���ʎ��ԗp
    private void Update()
    {
        a += Time.deltaTime;
        if (a > 3)     //�O�b����������ʂ��I������
        {
            Destroy(this.gameObject);
        }
    }

}
