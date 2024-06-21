using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMiddleRancher : MonoBehaviour
{
    float timeCount = 0; //弾を撃つまでの経過時間
    float shotAngle = 90;//発射角度
    [SerializeField] GameObject shotBullet; // 発射する弾

    void Update()
    {
        // 前フレームからの時間の差を加算
        timeCount += Time.deltaTime;

        // 1秒を超えているか
        if (timeCount > 1f)
        {
            timeCount = 0; // 再発射のために時間をリセット
            shotAngle += 10;
            // GameObjectを新たに生成する
            // 第一引数：生成するGameObject
            // 第二引数：生成する座標
            // 第三引数：生成する角度
            // 戻り値：生成したGameObject
            GameObject createObject = Instantiate(shotBullet, transform.position, Quaternion.identity);

            // 生成したGameObjectに設定されている、Bulletスクリプトを取得する
            BulletMiddle bulletScript = createObject.GetComponent<BulletMiddle>();
            if(shotAngle < 270)
            {
             // BulletスクリプトのInitを呼び出す
             bulletScript.Init(shotAngle, 3);
            }
            else
            {
                shotAngle = 90;
            }

            

        }
    }
}
