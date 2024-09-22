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
        
        if(transform.localScale.y<= 0)
        {
            transform.localScale = new Vector3(0f,0, 0f);
            Destroy(this.gameObject);
        }
        else
        {
            transform.localScale += new Vector3(0, 0.7f * -Time.deltaTime/2, 0f);
        }
    }
    public void OnCollisionEnter2D(Collision2D PlayerHit)
    {
        if(PlayerHit.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
