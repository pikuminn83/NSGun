using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public EnemyEnd _enemyEnd;
    //�X�R�A�\���̃e�L�X�g
    public TextMeshProUGUI ScoreText;
    //�S�̂̃X�R�A
    private int AllScore;
    //�^�C�}�[�\���̃e�L�X�g
    public TextMeshProUGUI TimerText;
    //Time.deltaTime�̕ϐ�
    private float Timer;
    //�Q�[���̏I������
    public float GameSetTimer = 0.0f;
    //�R���{�\���̃e�L�X�g
    public TextMeshProUGUI ConboText;
    //�R���{�{���̏����l
    private int CountConbo = 1;
    //�R���{��
    private int WidthAddConboCount;
    //Hit���̃R���{�J�E���g
    private int HitConboCount;
    //�ő�R���{��
    private int TopConboCount = 0;
    //�R���{�{���̕ω�����l
    public int WidthConboCount;
    //�����X�R�A
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
        ConboText.text = "�~" + CountConbo.ToString("F1");
        //�^�C���I�[�o�[���̏���
        if (Timer > GameSetTimer)
        {
            SceneManager.LoadScene("EndGame");
        }
        //�R���{�{����������
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
    //�X�R�A�̉��Z
    public void SumScore()
    {
        HitConboCount++;
        WidthAddConboCount++;
        //�ő�R���{��
        if(TopConboCount < WidthAddConboCount)
        {
            TopConboCount = WidthAddConboCount;
        }
        //EnemyManager��EnemyScoreAdd�ő��������ƃR���{�{���ŃX�R�A�̍��v�l���o��
        AllScore += _EnemyScore * CountConbo;
        //text�ɃX�R�A�\��
        ScoreText.text = "Score:" + AllScore;
        PlayerPrefs.SetInt("SCORE", AllScore);
        PlayerPrefs.SetInt("CONBO", TopConboCount);
        PlayerPrefs.Save();

    }

}
