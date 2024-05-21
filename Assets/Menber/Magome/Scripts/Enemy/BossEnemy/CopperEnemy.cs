using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Copperは銅
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

        // （ポイント）マイナスをかけることで逆方向に移動する。
        transform.Translate(transform.up * Time.deltaTime * 3 * Speed);

        if (pos.y > 2)
        {
            Speed = -1;
        }
        if (pos.y < -2)
        {
            Speed = 1;
        }
        BulletTime += Time.deltaTime;
       //弾の出現
       if(BulletTime > 5)
       {
            Instantiate(BulletObj, this.transform.position, Quaternion.identity);
            BulletTime = 0;
       }

        //ボスの生存時間
        LiveTimer += Time.deltaTime;
        if (LiveTimer > LiveGenerateTime)
        {
            // X方向に移動する。
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
                // X方向に移動する。
                transform.Translate(transform.right * Time.deltaTime * 3 * -1);
            }
        }
    }
}
