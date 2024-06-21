using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Copper�͓�
public class CopperEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject BulletObj;
    float BulletTime;

    private Vector2 pos;
    public int Speed;

    float LiveTimer;
    public float LiveGenerateTime;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = this.transform.position;

        // �i�|�C���g�j�}�C�i�X�������邱�Ƃŋt�����Ɉړ�����B
        transform.Translate(transform.up * Time.deltaTime * 3 * Speed);


        if (pos.y > 1)
        {
            Speed = -1;
        }
        if (pos.y < -3)

        {
            Speed = 1;
        }
        BulletTime += Time.deltaTime;
       //�e�̏o��
       if(BulletTime > 5)
       {
            Instantiate(BulletObj, this.transform.position, Quaternion.identity);
            BulletTime = 0;
       }

        //�{�X�̐�������
        LiveTimer += Time.deltaTime;

        if (LiveTimer > LiveGenerateTime)
        {
            // X�����Ɉړ�����B

            transform.Translate(transform.right * Time.deltaTime * 3 * 1);

            if (pos.x > 11)
            {
                Destroy(this.gameObject);
            }

        }
        else
        {

            if (pos.x > 5)
            {
                // X�����Ɉړ�����B

                transform.Translate(transform.right * Time.deltaTime * 3 * -1);
            }
        }
    }


}
