using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWood : MonoBehaviour
{
    Vector3 _EnemyMove;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        // �ړ����x��ێ�
        _EnemyMove = new Vector3(Speed, 0, 0);
        // �I�u�W�F�N�g�ړ�
        this.transform.position -= _EnemyMove * Time.deltaTime;
    }
}
