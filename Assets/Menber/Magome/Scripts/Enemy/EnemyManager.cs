using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //�G��̕��̃X�R�A
    public int Person_EnemyScore = 0;
    //�GHP
    public int HP = 0;

    public UIManager _uiManager;

    [SerializeField]
    private float explosionRadius; // �������a
    [SerializeField]
    public EnemyManager explosionEnemy;

    void Start()
    {
        GameObject _uiObj = GameObject.Find("Score");
        _uiManager = _uiObj.GetComponent<UIManager>();
    }
    public void OnCollisionEnter2D(Collision2D Hit)
    {
        //Bullet�̏ꍇ���������I�u�W�F�N�g����������
        //�����̃X�R�A��UIManager�Ƀv���X����
        if (Hit.gameObject.CompareTag("Bullet"))
        {
            HP--;
            EnemyScoreAdd();
        }

        if(Hit.gameObject.CompareTag("BulletSpecial"))

        {
           Debug.Log("BulletSpecial");
           BulletSpecial();
        }

        if(Hit.gameObject.CompareTag("Player"))

        {
            Debug.Log("Player Hit");
        }

    }
    public void BulletSpecial()
    {
        // �����͈͓̔��̃I�u�W�F�N�g�����o
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D colliderAll in colliders)
        {
            if(colliderAll.gameObject.CompareTag("Enemy"))
            {
                //����ɔ����_���[�W
                //��GlassRankEnemyParty�̓o�O��4�̂܂ł����|���Ȃ���X���؂ƏC��
                explosionEnemy = colliderAll.gameObject.GetComponent<EnemyManager>();
                explosionEnemy.HP--;
                EnemyScoreAdd();
                Destroy(colliderAll.gameObject);
               // Debug.Log($"���o���ꂽ�I�u�W�F�N�g {colliderAll.name}");
            }

        }

    }
    public void EnemyScoreAdd()
    {
        if (HP == 0)
        {
            _uiManager._EnemyScore = Person_EnemyScore;
            _uiManager.SumScore();
            Destroy(this.gameObject);
        }

    }

}
