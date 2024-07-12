using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMiddle : MonoBehaviour
{
    [SerializeField] float angle; // Šp“x
    [SerializeField] float speed; // ‘¬“x
    Vector3 velocity; // ˆÚ“®—Ê

    void Start()
    {
        // X•ûŒü‚ÌˆÚ“®—Ê‚ğİ’è‚·‚é
        velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

        // Y•ûŒü‚ÌˆÚ“®—Ê‚ğİ’è‚·‚é
        velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);


        // ’e‚ÌŒü‚«‚ğİ’è‚·‚é
        float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation = Quaternion.Euler(0, 0, zAngle);

        // n•bŒã‚Éíœ
        Destroy(gameObject, 6.0f);
    }
    void Update()
    {
        this.gameObject.transform.Rotate(0, 0, 10 + Time.deltaTime);
        // –ˆƒtƒŒ[ƒ€A’e‚ğˆÚ“®‚³‚¹‚é
        transform.position += velocity * Time.deltaTime;
    }
    // Šp“x‚Æ‘¬“x‚ğİ’è‚·‚éŠÖ”
    public void Init(float input_angle, float input_speed)
    {
        angle = input_angle;
        speed = input_speed;
    }
    public void OnCollisionEnter2D(Collision2D PlayerHit)
    {
        if (PlayerHit.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
