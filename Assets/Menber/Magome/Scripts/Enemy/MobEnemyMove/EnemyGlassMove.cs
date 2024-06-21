using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGlassMove : MonoBehaviour
{


    //���ꂼ��̈ʒu��ۑ�����ϐ�
    //�X�^�[�g�n�_
    private Vector2 charaPos;
    public Vector2 CharaPos { set { charaPos = value; } }
    //�S�[���n�_
    private Vector2 playerPos;
    public Vector2 PlayerPos { set { playerPos = value; } }
    //���p�n�_
    private Vector2 greenPos;
    public Vector2 GreenPos { set { greenPos = value; } }
    //�i�ފ������Ǘ�����ϐ�
    float time;

    private float currentTime = 0;
    private float targetTime = 0;
    private int count;

    //���p�n�_1
    public GameObject greenPoint;
    //���p�n�_2
    public GameObject greenPoint1;
    // Update is called once per frame
    void Update()
    {
        //�e�̐i�ފ�����Time.deltaTime�Ō��߂�
        time += Time.deltaTime;

        //�񎟃x�W�F�Ȑ�
        //�X�^�[�g�n�_���璆�p�n�_�܂ł̃x�N�g�����ʂ�_�̌��݂̈ʒu
        var a = Vector3.Lerp(charaPos, greenPos, time);
        //���p�n�_����^�[�Q�b�g�܂ł̃x�N�g�����ʂ�_�̌��݂̈ʒu
        var b = Vector3.Lerp(greenPos, playerPos, time);
        //��̓�̓_�����񂾃x�N�g�����ʂ�_�̌��݂̈ʒu�i�e�̈ʒu�j
        this.transform.position = Vector3.Lerp(a, b, time);




        //�e��0.1�b���Ƃɑł��o�����߂̂���
        currentTime += Time.deltaTime;
        if (targetTime < currentTime)
        {
            currentTime = 0;
            //�G�̈ʒu��ۑ�
            var pos = this.gameObject.transform.position;
            //�e�̏����ʒu��G�̈ʒu�ɂ���
            this.transform.position = pos;
            //�X�^�[�g�n�_��e�̃X�N���v�g�ɓn��
            CharaPos = this.transform.position;
            //�e����ł��o�����тɒ��p�n�_��ς���
            count++;
            //���p�n�_��e�̃X�N���v�g�ɓn��
            if (count % 2 == 1)
            {
                GreenPos = greenPoint.transform.position;
            }
            else
            {
                GreenPos = greenPoint1.transform.position;
            }
            //�v���C���[�i�^�[�Q�b�g�j�̈ʒu��e�̃X�N���v�g�ɓn��
            //PlayerPos = player.transform.position;
        }

    }
}
