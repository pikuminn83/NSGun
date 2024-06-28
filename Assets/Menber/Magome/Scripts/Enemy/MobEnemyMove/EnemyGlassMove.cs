using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGlassMove : MonoBehaviour
{
    Vector3 _EnemyMove;
    public float Speed;
    private bool Wallhit = false;
    // Update is called once per frame
    void Update()
    {
        if(Wallhit == false)
        {
            // �ړ����x��ێ�
            _EnemyMove = new Vector3(Speed, Speed, 0);
            // �I�u�W�F�N�g�ړ�
            this.transform.position -= _EnemyMove * Time.deltaTime;
        }
        if(Wallhit == true)
        {
            // �ړ����x��ێ�
            _EnemyMove = new Vector3(Speed, -Speed, 0);
            // �I�u�W�F�N�g�ړ�
            this.transform.position -= _EnemyMove * Time.deltaTime;
        }
    }
    void OnCollisionEnter2D(Collision2D hit)
    {

        if(hit.gameObject.CompareTag("Walltop"))

        {
            Wallhit = false;
        }
        else
        {
            Wallhit = true;
        }
    }
}
