using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMiddleRancher : MonoBehaviour
{
    float timeCount = 0; //�e�����܂ł̌o�ߎ���
    float shotAngle = 90;//���ˊp�x
    [SerializeField] GameObject shotBullet; // ���˂���e

    void Update()
    {
        // �O�t���[������̎��Ԃ̍������Z
        timeCount += Time.deltaTime;

        // 1�b�𒴂��Ă��邩
        if (timeCount > 1f)
        {
            timeCount = 0; // �Ĕ��˂̂��߂Ɏ��Ԃ����Z�b�g
            shotAngle += 10;
            // GameObject��V���ɐ�������
            // �������F��������GameObject
            // �������F����������W
            // ��O�����F��������p�x
            // �߂�l�F��������GameObject
            GameObject createObject = Instantiate(shotBullet, transform.position, Quaternion.identity);

            // ��������GameObject�ɐݒ肳��Ă���ABullet�X�N���v�g���擾����
            BulletMiddle bulletScript = createObject.GetComponent<BulletMiddle>();
            if(shotAngle < 270)
            {
             // Bullet�X�N���v�g��Init���Ăяo��
             bulletScript.Init(shotAngle, 3);
            }
            else
            {
                shotAngle = 90;
            }

            

        }
    }
}
