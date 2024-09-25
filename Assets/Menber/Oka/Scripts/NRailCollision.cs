using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NRailCollision : MonoBehaviour
{

    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Player>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.Nflag = true;
        }
    }

        private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.Nflag = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
