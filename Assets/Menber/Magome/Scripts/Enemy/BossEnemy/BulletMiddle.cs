using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMiddle : MonoBehaviour
{
    [SerializeField] float angle; // �p�x
    [SerializeField] float speed; // ���x
    Vector3 velocity; // �ړ���

    void Start()
    {
        // X�����̈ړ��ʂ�ݒ肷��
        velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

        // Y�����̈ړ��ʂ�ݒ肷��
        velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);


        // �e�̌�����ݒ肷��
        float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation = Quaternion.Euler(0, 0, zAngle);

        // n�b��ɍ폜
        Destroy(gameObject, 6.0f);
    }
    void Update()
    {
        this.gameObject.transform.Rotate(0, 0, 10 + Time.deltaTime);
        // ���t���[���A�e���ړ�������
        transform.position += velocity * Time.deltaTime;
    }
    // �p�x�Ƒ��x��ݒ肷��֐�
    public void Init(float input_angle, float input_speed)
    {
        angle = input_angle;
        speed = input_speed;
    }
}