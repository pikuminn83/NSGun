using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public EnemyEnd _enemyEnd;

    public TextMeshProUGUI ScoreText;//�X�R�A�\���̃e�L�X�g    
    public TextMeshProUGUI TimerText;//�^�C�}�[�\���̃e�L�X�g
    public TextMeshProUGUI ConboText;//�R���{�\���̃e�L�X�g

    public float GameSetTimer = 0.0f;//�Q�[���̏I������

    private int WidthAddConboCount;  //�R���{��
    [System.NonSerialized]
    public int HitConboCount;�@�@�@ //Hit���̃R���{�J�E���g
    private int TopConboCount;�@//�ő�R���{��
    public int WidthConboCount;�@�@ //�R���{�{���̕ω�����l
    private int AllScore;            //�S�̂̃X�R�A
    [System.NonSerialized]
    public int _EnemyScore = 0; //�����X�R�A
    [System.NonSerialized]
    public int CountConbo = 1; //�R���{�{���̏����l
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
        ConboText.text = "�~" + CountConbo.ToString("F1");
        //�^�C���I�[�o�[���̏���
        if (0 > GameSetTimer)
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
        if (TopConboCount <= WidthAddConboCount)
        {
            TopConboCount = WidthAddConboCount;
        }
        //EnemyManager��EnemyScoreAdd�ő��������ƃR���{�{���ŃX�R�A�̍��v�l���o��
        AllScore += _EnemyScore * CountConbo;
        //text�ɃX�R�A�\��
        ScoreText.text = "Score:" + AllScore;
        PlayerPrefs.SetInt("SCORE", AllScore);
        PlayerPrefs.SetInt("COMBO", TopConboCount);
        PlayerPrefs.Save();

    }

}
