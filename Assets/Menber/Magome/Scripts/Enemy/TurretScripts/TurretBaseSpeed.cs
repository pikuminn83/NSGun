using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBaseSpeed : MonoBehaviour
{
    private Vector3 TurretEnemyVec;
    public float Speed;
    // Update is called once per frame
    void Update()
    {
        // �ړ����x��ێ�
        TurretEnemyVec = new Vector3(Speed, 0, 0);
        this.transform.position -= TurretEnemyVec * Time.deltaTime;
    }
}
