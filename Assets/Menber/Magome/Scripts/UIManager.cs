using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public EnemyManager _enemyManager;

    //スコア表示のテキスト
    public TextMeshProUGUI ScoreText;
    //全体のスコア
    private int AllScore;
    //タイマー表示のテキスト
    public TextMeshProUGUI TimerText;
    //Time.deltaTimeの変数
    private float Timer;
    //ゲームの終了時間
    public float GameSetTimer =0.0f;

    public TextMeshProUGUI ConboText;
    private int ConboCount = 1;
    private int ConboCountWidthAdd;
    public int ConboCountWidth;

    private bool InCamera =false;
    public int _EnemyScore = 0;
    void Start()
    {
        ConboText.text = "×" + ConboCount.ToString("F1");

        AllScore = 0;
        ScoreText.text = "Score:" + AllScore;
        PlayerPrefs.SetInt("SCORE", AllScore);
        PlayerPrefs.Save();

    }
    void FixedUpdate()
    {
        Timer += Time.deltaTime;
        TimerText.text = "TImer:" + Timer.ToString("F1");
        if (Timer > GameSetTimer)
        {
            SceneManager.LoadScene("EndGame");
        }
        if(InCamera ==true)
        {
            if(ConboCountWidthAdd==ConboCountWidth&&ConboCount<4)
            {
                ConboCount++;
                ConboText.text = "×"+ConboCount.ToString("F1");
                ConboCountWidthAdd = 0;
            }
            
        }
        if(InCamera == false)
        {
            ConboCount=1;
        }
    }
    //スコアの加算
    public void SumScore()
    {
        ConboCountWidthAdd++;
        AllScore += _EnemyScore*ConboCount;
        //textにスコア表示
        ScoreText.text = "Score:"+AllScore;
        PlayerPrefs.SetInt("SCORE",AllScore);
        PlayerPrefs.SetInt("CONBO", ConboCountWidthAdd);
        PlayerPrefs.Save();
      
    }
    public void EnemyOutsideCamera()
   {
        //InCamera = false;
    }
    public void EnemyInCamera()
    {
        InCamera = true;
    }

}
