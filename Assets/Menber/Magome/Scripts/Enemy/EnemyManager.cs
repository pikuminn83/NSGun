using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class EnemyManager : MonoBehaviour
{
    
    public int Person_EnemyScore = 0;//自分のスコア
    
    public int HP = 0;//自分のHP

    public UIManager _uiManager;

    [SerializeField]
    private float explosionRadius; //爆発範囲
    [SerializeField]
    public EnemyManager explosionEnemy;
    
    public ParticleSystem DeathParticl;//死んだ時のパーティクル
    public AudioSource DeathSE;
    void Start()
    {
        DeathSE = GetComponent<AudioSource>();
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
            _uiManager.CountConbo = 1;
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

            }

        }

    }
    public void EnemyScoreAdd()
    {
        //HPが0になったらエフェクトと自分を消す
        if (HP == 0)
        {
            _uiManager._EnemyScore = Person_EnemyScore;
            _uiManager.SumScore();
            //エフェクトが消えるまでの秒数
            DeathActionEnemy(1000);
        }
    }
    private async void DeathActionEnemy(int Delay)
    {
            DeathParticl = Instantiate(DeathParticl, transform);
            DeathParticl.Play(true);
            DeathSE.Play();
            //死んだときのエフェクトを出すために遅らせる
            await UniTask.Delay(Delay);
            Destroy(this.gameObject);
    }

}
