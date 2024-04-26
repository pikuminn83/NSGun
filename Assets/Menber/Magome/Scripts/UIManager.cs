using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public EnemyManager _Score;

    private int AllScore = 0;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void SumScore()
    {
        int _EnemyScore = _Score.EnemyScore;
        AllScore += _EnemyScore;
        Debug.Log(AllScore + "Score");
    }

}
