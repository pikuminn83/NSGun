using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public EnemyEnd _enemyEnd;
    //スコア表示のテキスト
    public TextMeshProUGUI ScoreText;
    //全体のスコア
    private int AllScore;
    //タイマー表示のテキスト
    public TextMeshProUGUI TimerText;
    //Time.deltaTimeの変数
    private float Timer;
    //ゲームの終了時間
    public float GameSetTimer = 0.0f;
    //コンボ表示のテキスト
    public TextMeshProUGUI ConboText;
    //コンボ倍率の初期値
    private int CountConbo = 1;
    //コンボ数
    private int WidthAddConboCount;
    //Hit時のコンボカウント
    private int HitConboCount;
    //最大コンボ数
    private int TopConboCount = 0;
    //コンボ倍率の変化する値
    public int WidthConboCount;
    //初期スコア
    public int _EnemyScore = 0;
    void Start()
    {
        AllScore = 0;
        ScoreText.text = "Score:" + AllScore;
        PlayerPrefs.SetInt("SCORE", AllScore);
        PlayerPrefs.Save();

    }
    void FixedUpdate()
    {
        Timer += Time.deltaTime;
        TimerText.text = "TImer:" + Timer.ToString("F1");
        ConboText.text = "×" + CountConbo.ToString("F1");
        //タイムオーバー時の処理
        if (Timer > GameSetTimer)
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
        if(TopConboCount < WidthAddConboCount)
        {
            TopConboCount = WidthAddConboCount;
        }
        //EnemyManagerのEnemyScoreAddで足した物とコンボ倍率でスコアの合計値を出す
        AllScore += _EnemyScore * CountConbo;
        //textにスコア表示
        ScoreText.text = "Score:" + AllScore;
        PlayerPrefs.SetInt("SCORE", AllScore);
        PlayerPrefs.SetInt("CONBO", TopConboCount);
        PlayerPrefs.Save();

    }

}
