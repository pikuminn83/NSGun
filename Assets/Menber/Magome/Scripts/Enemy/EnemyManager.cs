using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public int EnemyScore = 0;

    public UIManager _uiManager;
    // Update is called once per frame

    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D Hit)
    {
        //Œ»İ‚ÍƒvƒŒƒCƒ„[‚ğBullet‚É‚µ‚Ä‚¢‚é
        if (Hit.gameObject.CompareTag("Bullet"))
        {
           
            EnemyScoreAdd();
        }
        
    }
    public void EnemyScoreAdd()
    {
        
        GameObject _uiObj = GameObject.Find("Score");
        _uiManager = _uiObj.GetComponent<UIManager>();
        _uiManager.SumScore();
        Destroy(this.gameObject);
    }

}
