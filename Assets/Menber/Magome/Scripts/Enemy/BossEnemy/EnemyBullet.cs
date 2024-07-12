using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int BulletSpeed;
    [System.NonSerialized]
    public UIManager _uiManager;
    public AudioSource SEBullet;
    private void Start()
    {
        GameObject _uiObj = GameObject.Find("Score");
        _uiManager = _uiObj.GetComponent<UIManager>();
        SEBullet.PlayOneShot(SEBullet.clip);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right*Time.deltaTime*2*-BulletSpeed);
    }
    public void OnCollisionEnter2D(Collision2D PlayerHit)
    {
        if(PlayerHit.gameObject.CompareTag("Player"))
        {
            _uiManager.CountConbo = 1;
            _uiManager.HitConboCount = 0;
            Destroy(this.gameObject);
        }
    }
}
