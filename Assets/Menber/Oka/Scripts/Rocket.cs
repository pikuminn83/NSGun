using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float RocketSpeed = 5.0f;
    float a = 0;
    CircleCollider2D cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        cc.isTrigger = true;
        cc.radius = 2.0f;
        Invoke("OnDestroy", 0.01f);
    }

    private void OnDestroy()
    {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(RocketSpeed * Time.deltaTime, 0, 0);
        a += Time.deltaTime;
        if (a > 3)
        {
            Destroy(this.gameObject);
        }
    }
}
