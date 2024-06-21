using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldEnemy : MonoBehaviour
{
    //���˂���e
    [SerializeField]
    GameObject LaneBulletObj;
    //��������ʒu
    [SerializeField]
    private GameObject TopPosBarrel;
    [SerializeField]
    private GameObject UnderBarrel;
    //�e�����܂ł̌o�ߎ���
    float BulletTime;
    //�����_���Ō��ꏊ�����߂�
    private int BulletRandom;
    private Vector2 pos;
    private float Speed;
    // Update is called once per frame
    void Update()
    {
        pos = this.transform.position;
        //�{�X���t�B�[���h�ɂ���Ƃ��̍s��
        if (pos.x > 8)
        {
            // +X�����Ɉړ�����B
            transform.Translate(transform.right * Time.deltaTime * 3 * -1);
        }
        BulletTime += Time.deltaTime;
        //�e�̏o��
        if (BulletTime > 5)
        {
            //�����_���ŏ㉺�ǂ��炩�̃��[���ɒe������
            BulletRandom = Random.Range(0, 2);
            switch (BulletRandom)
            {
                case 0:
                    Instantiate(LaneBulletObj, TopPosBarrel.transform.position, Quaternion.identity);
                    BulletTime = 0;
                    break;
                case 1:
                    Instantiate(LaneBulletObj, UnderBarrel.transform.position, Quaternion.identity);
                    BulletTime = 0;
                    break;

            }
        }

    }
}
