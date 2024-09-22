using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGlassMove : MonoBehaviour
{
    Vector3 _EnemyMove;
    public float Speed;
    private bool Wallhit = false;
    // Update is called once per frame
    void Update()
    {
        if(Wallhit == false)
        {
            _EnemyMove = new Vector3(Speed, Speed, 0);
            this.transform.position -= _EnemyMove * Time.deltaTime;
        }
        if(Wallhit == true)
        {
            _EnemyMove = new Vector3(Speed, -Speed, 0);
            this.transform.position -= _EnemyMove * Time.deltaTime;
        }
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.CompareTag("NRail"))
        {
            Wallhit = false;
        }
        else if((hit.gameObject.CompareTag("SRail")))
        {
            Wallhit = true;
        }
        else
        {
            Wallhit = false;
        }
    }

}
