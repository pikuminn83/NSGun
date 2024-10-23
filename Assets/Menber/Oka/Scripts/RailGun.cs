using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class RailGun : MonoBehaviour
{

    [SerializeField] private Sprite[] images;
    private GameObject pl;
    Player player;
    Rigidbody2D rb2;
    Transform pltf;
    SpriteRenderer sprite;
    SpriteRenderer mysprite;

    float a = 0; //Œø‰ÊŽžŠÔ—p

    private void Start()
    {
        pl = GameObject.Find("Player");
        player = pl.GetComponent<Player>();
        rb2 = pl.GetComponent <Rigidbody2D>();
        mysprite = GetComponent<SpriteRenderer>();
        sprite = pl.GetComponent<SpriteRenderer>();
        pltf = pl.transform;
        player.RailGunFlag = true;
        StartCoroutine("RailGunEffect");
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

    private IEnumerator RailGunEffect()
    {
        for(int i = 0; i < 10; i++ )
        {
            mysprite.sprite = images[i];

            yield return new WaitForSeconds(0.1f);
            Debug.Log(i);
        }


        yield break;
    }
}
