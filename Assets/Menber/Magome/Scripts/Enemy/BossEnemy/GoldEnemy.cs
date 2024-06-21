using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldEnemy : MonoBehaviour
{
    //発射する弾
    [SerializeField]
    GameObject LaneBulletObj;
    //生成する位置
    [SerializeField]
    private GameObject TopPosBarrel;
    [SerializeField]
    private GameObject UnderBarrel;
    //弾を撃つまでの経過時間
    float BulletTime;
    //ランダムで撃つ場所を決める
    private int BulletRandom;
    private Vector2 pos;
    private float Speed;
    // Update is called once per frame
    void Update()
    {
        pos = this.transform.position;
        //ボスがフィールドにいるときの行動
        if (pos.x > 8)
        {
            // +X方向に移動する。
            transform.Translate(transform.right * Time.deltaTime * 3 * -1);
        }
        BulletTime += Time.deltaTime;
        //弾の出現
        if (BulletTime > 5)
        {
            //ランダムで上下どちらかのレーンに弾を撃つ
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
