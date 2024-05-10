using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public int EnemyScore = 0;

    public UIManager _uiManager;

    [SerializeField]
    private float explosionRadius; // �������a

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
    public void EnemyScoreAdd()
    {

        GameObject _uiObj = GameObject.Find("Score");
        _uiManager = _uiObj.GetComponent<UIManager>();
        //_uiManager.SumScore();
        // �����͈͓̔��̃I�u�W�F�N�g�����o
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D collider in colliders)
        {
            //�G��|�������̃|�C���g���Z
            if (collider.gameObject.CompareTag("Enemy"))
            {
                _uiManager.SumScore();
                Destroy(collider.gameObject);
            }

        }

    }

}
