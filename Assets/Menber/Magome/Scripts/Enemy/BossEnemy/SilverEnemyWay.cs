using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SilverEnemyWay : MonoBehaviour
{
    //�ړ�����X�L��
    [SerializeField]
    Transform moveSkin;
    //�ړ��X�s�[�h
    [SerializeField]
    float Speed;

    float LiveTimer;
    public float LiveGenerateTime;
    //�q�v�f��Points���i�[���郊�X�g
    List<Transform> Points;
    //Point�̏��ԗp
    int PointIndex = 0;
    Vector3 NextPos;

    void Start()
    {
        //List������
        Points = new List<Transform>();
        //�����ȊO�̎q�v�f��transform��List�ɒǉ�
        Points = GetComponentsInChildren<Transform>().Where(t => t != transform).ToList();
        //�i�ރ|�C���g�̍��W���w��ipoints[0]��position�j
        NextPos = Points[PointIndex].position;
    }

    void Update()
    {
        //�|�C���g0�͂��̏ꏊ�Ɉړ�������
        if (PointIndex == 0)
        {
            moveSkin.position = Points[PointIndex].position;
        }
        //���̃|�C���g����ړ�������
        if ((NextPos - moveSkin.position).sqrMagnitude > Mathf.Epsilon)
        {
            moveSkin.position = Vector3.MoveTowards(moveSkin.position, NextPos, Speed * Time.deltaTime);
        }
        else
        {
            PointIndex++;
            //�|�C���g�܂ňړ��������玟�̃|�C���g�ɕύX
            if (PointIndex < Points.Count)
            {
                NextPos = Points[PointIndex].position;
            }
            //�Ō�܂ōs�����珉��������
            else if (PointIndex > Points.Count)
            {
                //�|�C���g�̍��W��������
                PointIndex = 0;
                //�i�ރ|�C���g�̍��W���w��ipoints[0]��position�j
                NextPos = Points[PointIndex].position;
            }

        }
        //�{�X�̐�������
        LiveTimer += Time.deltaTime;
        if (LiveTimer >= LiveGenerateTime)
        {
            // -X�����Ɉړ�����B
            transform.Translate(transform.right * Time.deltaTime * 5);
            Invoke("EnemyDeath",5.0f);
            
        }
        //�{�X���t�B�[���h�ɂ���Ƃ��̍s��
        if (this.transform.position.x > 7.5 && LiveTimer < LiveGenerateTime)
        {
            // +X�����Ɉړ�����B
            transform.Translate(transform.right * Time.deltaTime * -3);
        }
    }
    void EnemyDeath()
    {
     Destroy(this.gameObject);
    }
}
