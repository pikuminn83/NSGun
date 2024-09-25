using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{

    [SerializeField] GameObject player;
    MagneticGage mg;
    SpriteRenderer sprite;
    public bool damageFlag = false;
    int alpha = 255;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Gage = GameObject.Find("MagneticGage");
        mg = Gage.GetComponent<MagneticGage>();
        sprite = player.GetComponent<SpriteRenderer>();
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (damageFlag == false)
        {
            
            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
            {
                damageFlag = true;
                time = 0;
                Invoke("FlagOff", 2);
            }

        }
    }
    
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(damageFlag)
        {
            sprite.color = new Color(255, 255, 255, alpha);
            
            if(time > 0.1)
            {
                time = 0;
                alpha *= -1;
            }  
        }
        //Debug.Log(damageFlag);
    }

    void FlagOff()
    {
        damageFlag = false;
        sprite.color = new Color(255, 255, 255, 255);
        alpha = 255;
    }
}
