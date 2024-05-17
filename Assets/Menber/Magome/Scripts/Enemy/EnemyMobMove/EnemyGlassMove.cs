using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGlassMove : MonoBehaviour
{

    //それぞれの位置を保存する変数
    //スタート地点
    private Vector2 charaPos;
    public Vector2 CharaPos { set { charaPos = value; } }
    //ゴール地点
    private Vector2 playerPos;
    public Vector2 PlayerPos { set { playerPos = value; } }
    //中継地点
    private Vector2 greenPos;
    public Vector2 GreenPos { set { greenPos = value; } }
    //進む割合を管理する変数
    float time;

    private float currentTime = 0;
    private float targetTime = 0;
    private int count;

    //中継地点1
    public GameObject greenPoint;
    //中継地点2
    public GameObject greenPoint1;
    // Update is called once per frame
    void Update()
    {
        //弾の進む割合をTime.deltaTimeで決める
        time += Time.deltaTime;

        //二次ベジェ曲線
        //スタート地点から中継地点までのベクトル上を通る点の現在の位置
        var a = Vector3.Lerp(charaPos, greenPos, time);
        //中継地点からターゲットまでのベクトル上を通る点の現在の位置
        var b = Vector3.Lerp(greenPos, playerPos, time);
        //上の二つの点を結んだベクトル上を通る点の現在の位置（弾の位置）
        this.transform.position = Vector3.Lerp(a, b, time);




        //弾を0.1秒ごとに打ち出すためのもの
        currentTime += Time.deltaTime;
        if (targetTime < currentTime)
        {
            currentTime = 0;
            //敵の位置を保存
            var pos = this.gameObject.transform.position;
            //弾の初期位置を敵の位置にする
            this.transform.position = pos;
            //スタート地点を弾のスクリプトに渡す
            CharaPos = this.transform.position;
            //弾を一つ打ち出すたびに中継地点を変える
            count++;
            //中継地点を弾のスクリプトに渡す
            if (count % 2 == 1)
            {
                GreenPos = greenPoint.transform.position;
            }
            else
            {
                GreenPos = greenPoint1.transform.position;
            }
            //プレイヤー（ターゲット）の位置を弾のスクリプトに渡す
            //PlayerPos = player.transform.position;
        }

    }
}
