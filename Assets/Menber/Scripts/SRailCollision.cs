using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRailCollision : MonoBehaviour
{

    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Player>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        player.Sflag = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        player.Sflag = false;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
