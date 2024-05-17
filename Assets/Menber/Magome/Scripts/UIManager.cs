using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public EnemyManager _enemyManager;

    //�X�R�A�\���̃e�L�X�g
    public TextMeshProUGUI ScoreText;
    //�S�̂̃X�R�A
    private int AllScore;
    //�^�C�}�[�\���̃e�L�X�g
    public TextMeshProUGUI TimerText;
    //Time.deltaTime�̕ϐ�
    private float Timer;
    //�Q�[���̏I������
    public float GameSetTimer =0.0f;

    public TextMeshProUGUI ConboText;
    private int ConboCount = 1;
    private int ConboCountWidthAdd;
    public int ConboCountWidth;

    private bool InCamera =false;
    public int _EnemyScore = 0;
    void Start()
    {
        ConboText.text = "�~" + ConboCount.ToString("F1");

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
                ConboText.text = "�~"+ConboCount.ToString("F1");
                ConboCountWidthAdd = 0;
            }
            
        }
        if(InCamera == false)
        {
            ConboCount=1;
        }
    }
    //�X�R�A�̉��Z
    public void SumScore()
    {
        ConboCountWidthAdd++;
        AllScore += _EnemyScore*ConboCount;
        //text�ɃX�R�A�\��
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
