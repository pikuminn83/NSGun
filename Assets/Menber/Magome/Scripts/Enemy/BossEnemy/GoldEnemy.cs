using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject LaneBulletObj;

    [SerializeField]
    private GameObject TopPosBarrel;
    [SerializeField]
    private GameObject UnderBarrel;

    float BulletTime;

    private int BulletRandom;
    private Vector2 pos;
    public int Speed;

    public float LiveGenerateTime;


    // Update is called once per frame
    void Update()
    {

        pos = this.transform.position;
        BulletTime += Time.deltaTime;
        //’e‚ÌoŒ»
        if (BulletTime > 5)
        {
            //ƒ‰ƒ“ƒ_ƒ€‚Åã‰º‚Ç‚¿‚ç‚©‚ÌƒŒ[ƒ“‚É’e‚ðŒ‚‚Â
            BulletRandom = Random.Range(0, 2);
            switch (BulletRandom)
            {
                case 0:
                    Instantiate(LaneBulletObj, TopPosBarrel.transform.position, Quaternion.identity);
                    BulletTime = 0;
                    break;
                case 1:
                    Instantiate(LaneBulletObj, UnderBarrel.transform.position, Quaternion.identity);
                    BulletTime = 0;
                    break;

            }
        }

        if (pos.x >= 10)
        {
            transform.Translate(transform.right * Time.deltaTime * 3 * -1);
        }
    }
}
