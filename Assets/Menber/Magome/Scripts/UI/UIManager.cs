using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public EnemyEnd _enemyEnd;

    public TextMeshProUGUI ScoreText;//スコア表示のテキスト    
    public TextMeshProUGUI TimerText;//タイマー表示のテキスト
    public TextMeshProUGUI ConboText;//コンボ表示のテキスト

    public float GameSetTimer = 0.0f;//ゲームの終了時間

    private int WidthAddConboCount;  //コンボ数
    [System.NonSerialized]
    public int HitConboCount;　　　 //Hit時のコンボカウント
    private int TopConboCount;　//最大コンボ数
    public int WidthConboCount;　　 //コンボ倍率の変化する値
    private int AllScore;            //全体のスコア
    [System.NonSerialized]
    public int _EnemyScore = 0; //初期スコア
    [System.NonSerialized]
    public int CountConbo = 1; //コンボ倍率の初期値
    void Start()
    {
        TopConboCount = 0;
        AllScore = 0;
        ScoreText.text = "Score:" + AllScore;
        PlayerPrefs.SetInt("CONBO", TopConboCount);
        PlayerPrefs.SetInt("SCORE", AllScore);
        PlayerPrefs.Save();

    }
    void FixedUpdate()
    {
        GameSetTimer -= Time.deltaTime;
        TimerText.text = "Timer:" + GameSetTimer.ToString("F1");
        ConboText.text = "×" + CountConbo.ToString("F1");
        //タイムオーバー時の処理
        if (0 > GameSetTimer)
        {
            SceneManager.LoadScene("EndGame");
        }
        //コンボ倍率をあげる
        if (HitConboCount == WidthConboCount && CountConbo < 4)
        {
            CountConbo++;
            HitConboCount = 0;
        }
        if (_enemyEnd.OutsideCamera == true)
        {
            CountConbo = 1;
            HitConboCount = 0;
            _enemyEnd.OutsideCamera = false;
        }
    }
    //スコアの加算
    public void SumScore()
    {
        HitConboCount++;
        WidthAddConboCount++;
        //最大コンボ数
        if (TopConboCount <= WidthAddConboCount)
        {
            TopConboCount = WidthAddConboCount;
        }
        //EnemyManagerのEnemyScoreAddで足した物とコンボ倍率でスコアの合計値を出す
        AllScore += _EnemyScore * CountConbo;
        //textにスコア表示
        ScoreText.text = "Score:" + AllScore;
        PlayerPrefs.SetInt("SCORE", AllScore);
        PlayerPrefs.SetInt("COMBO", TopConboCount);
        PlayerPrefs.Save();

    }

}
