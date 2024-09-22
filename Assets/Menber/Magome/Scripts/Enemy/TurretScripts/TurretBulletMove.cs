using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletMove : MonoBehaviour
{
    public float Speed;
    private GameObject Target;
    void Start()
    {
        Target = GameObject.Find("Player");
        Vector3 diff = (Target.gameObject.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);
    }
    void Update()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * Speed);

    }
}
