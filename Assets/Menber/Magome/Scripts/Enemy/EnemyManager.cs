using System.Collections;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class EnemyManager : MonoBehaviour
{

    public int Person_EnemyScore = 0;//自分のスコア

    public int HP = 0;//自分のHP

    public UIManager _uiManager;

    private float AlphaTime;
    private bool AlphaChange = false;
    [SerializeField]
    private float explosionRadius; //爆発範囲
    [SerializeField]
    public EnemyManager explosionEnemy;
    public ParticleSystem DeathParticl;//死んだ時のパーティクル
    public AudioSource DeathSE;

    float alpha_Sin;
    void Start()
    {
        DeathSE = GetComponent<AudioSource>();
        GameObject _uiObj = GameObject.Find("Score");
        _uiManager = _uiObj.GetComponent<UIManager>();
    }
    private void Update()
    {
        if (AlphaChange == true)
        {
            AlphaTime += Time.deltaTime;
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f - AlphaTime);
            this.transform.position += new Vector3(0,0.5f*-Time.deltaTime);
        }
        else
        {
            AlphaTime = 0;
        }

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

        if (Hit.gameObject.CompareTag("BulletSpecial"))
        {
            BulletSpecialScore();
        }
        if (Hit.gameObject.CompareTag("Player"))
        {
            _uiManager.CountConbo = 1;
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
            DeathActionEnemy(500);
            Destroy(this.gameObject,0.5f);

        }

    }
    public void BulletSpecialScore()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D colliderAll in colliders)
        {
            if (colliderAll.gameObject.CompareTag("Enemy"))
            {
                explosionEnemy = colliderAll.gameObject.GetComponent<EnemyManager>();
                explosionEnemy.HP--;
                if (HP < 0 || HP == 0)
                {
                    _uiManager._EnemyScore = Person_EnemyScore;
                    _uiManager.SumScore();
                    DeathActionEnemy(500);
                    DeathParticl = Instantiate(DeathParticl, colliderAll.transform);
                    Destroy(colliderAll.gameObject,0.5f);
                }
            }
        }
    }
    private async void DeathActionEnemy(int Delay)
    {
        DeathParticl = Instantiate(DeathParticl, transform);
        DeathParticl.Play(true);
        DeathSE.Play();
        AlphaChange = true;
        await UniTask.Delay(Delay);
        AlphaChange = false;
    }

}
