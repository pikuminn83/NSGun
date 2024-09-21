using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SilverEnemyWay : MonoBehaviour
{
    //移動するスキン
    [SerializeField]
    Transform moveSkin;
    //移動スピード
    [SerializeField]
    float Speed;

    float LiveTimer;
    public float LiveGenerateTime;
    //子要素のPointsを格納するリスト
    List<Transform> Points;
    //Pointの順番用
    int PointIndex = 0;
    Vector3 NextPos;

    void Start()
    {
        //List初期化
        Points = new List<Transform>();
        //自分以外の子要素のtransformをListに追加
        Points = GetComponentsInChildren<Transform>().Where(t => t != transform).ToList();
        //進むポイントの座標を指定（points[0]のposition）
        NextPos = Points[PointIndex].position;
    }

    void Update()
    {
        //ポイント0はその場所に移動させる
        if (PointIndex == 0)
        {
            moveSkin.position = Points[PointIndex].position;
        }
        //次のポイントから移動させる
        if ((NextPos - moveSkin.position).sqrMagnitude > Mathf.Epsilon)
        {
            moveSkin.position = Vector3.MoveTowards(moveSkin.position, NextPos, Speed * Time.deltaTime);
        }
        else
        {
            PointIndex++;
            //ポイントまで移動させたら次のポイントに変更
            if (PointIndex < Points.Count)
            {
                NextPos = Points[PointIndex].position;
            }
            //最後まで行ったら初期化する
            else if (PointIndex > Points.Count)
            {
                //ポイントの座標を初期化
                PointIndex = 0;
                //進むポイントの座標を指定（points[0]のposition）
                NextPos = Points[PointIndex].position;
            }

        }
        //ボスの生存時間
        LiveTimer += Time.deltaTime;
        if (LiveTimer >= LiveGenerateTime)
        {
            // -X方向に移動する。
            transform.Translate(transform.right * Time.deltaTime * 5);
            Invoke("EnemyDeath",5.0f);
            
        }
        //ボスがフィールドにいるときの行動
        if (this.transform.position.x > 7.5 && LiveTimer < LiveGenerateTime)
        {
            // +X方向に移動する。
            transform.Translate(transform.right * Time.deltaTime * -3);
        }
    }
    void EnemyDeath()
    {
     Destroy(this.gameObject);
    }
}
