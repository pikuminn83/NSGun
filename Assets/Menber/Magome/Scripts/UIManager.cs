using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public EnemyManager _Score;

    public TextMeshProUGUI ScoreText;
    private int AllScore = 0;

    public TextMeshProUGUI TimerText;
    private float Timer;
    public float GameSetTimer =0.0f;
    void Start()
    {
        AllScore = 0;
        ScoreText.text = "Score:" + AllScore;
    }
    void FixedUpdate()
    {
        Timer += Time.deltaTime;
        TimerText.text = "TImer:" + Timer.ToString("F1");
        if (Timer > GameSetTimer)
        {
            SceneManager.LoadScene("EndGame");
        }
    }
    //スコアの加算
    public void SumScore()
    {
        int _EnemyScore = _Score.EnemyScore;
        AllScore += _EnemyScore;
        //textにスコア表示
        ScoreText.text = "Score:"+AllScore;
        PlayerPrefs.SetInt("SCORE",AllScore);
        PlayerPrefs.Save();
      
    }

}
