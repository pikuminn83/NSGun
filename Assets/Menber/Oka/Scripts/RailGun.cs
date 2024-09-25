using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class RailGun : MonoBehaviour
{
    private GameObject pl;
    Player player;
    Rigidbody2D rb2;
    Transform pltf;
    SpriteRenderer sprite;
    float a = 0; //Œø‰ÊŽžŠÔ—p

    private void Start()
    {
        pl = GameObject.Find("Player");
        player = pl.GetComponent<Player>();
        rb2 = pl.GetComponent <Rigidbody2D>();
        sprite = pl.GetComponent<SpriteRenderer>();
        pltf = pl.transform;
        player.RailGunFlag = true;
    }
    private void Update()
    {
        a += Time.deltaTime;
        if (a > 1)     //1•b‚½‚Á‚½‚çŒø‰Ê‚ðI—¹‚·‚é
        {
            player.RailGunFlag = false;
            Destroy(this.gameObject);
            if (pltf.position.y > -0.75)
            {
                rb2.gravityScale = -3.0f;
                var spriteRenderer = player.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = player.StoN;
                sprite.flipY = false;

            }
            if (pltf.position.y < -0.75)
            {
                rb2.gravityScale = 3.0f;
                var spriteRenderer = player.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = player.NtoS;
                sprite.flipY = true;
            }
            
        }
    }

}
