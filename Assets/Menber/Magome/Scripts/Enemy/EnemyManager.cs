using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //�G��̕��̃X�R�A
    public int Person_EnemyScore = 0;
    //�GHP

    public int HP=0;


    public UIManager _uiManager;

    [SerializeField]
    private float explosionRadius; // �������a


    void Start()
    {
        GameObject _uiObj = GameObject.Find("Score");
        _uiManager = _uiObj.GetComponent<UIManager>();
    }

    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D Hit)
    {
        //���݂̓v���C���[��Bullet�ɂ��Ă���
        if (Hit.gameObject.CompareTag("Bullet"))
        {

            EnemyScoreAdd();
        }

    }
    public void BulletSpecial()
    {



    }
    public void EnemyScoreAdd()
    {

        // �����͈͓̔��̃I�u�W�F�N�g�����o
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D collider in colliders)
        {
            //�G��|�������̃|�C���g���Z
            if (collider.gameObject.CompareTag("Enemy"))
            {
                HP--;
                if(HP == 0)
                {
                    _uiManager._EnemyScore = Person_EnemyScore;
                   _uiManager.SumScore();
                   Destroy(this.gameObject);
                }
            }
        }
    }

}
