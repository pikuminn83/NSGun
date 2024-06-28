using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int BulletSpeed;

    public AudioSource SEBullet;
    private void Start()
    {
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
            Destroy(this.gameObject);
        }
    }
}
