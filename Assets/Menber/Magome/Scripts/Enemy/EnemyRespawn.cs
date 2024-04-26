using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public List<GameObject> Respwan = new List<GameObject>();

    public Transform Pos1;
    public Transform Pos2;

    float MaxX, Minx, MaxY, Miny;
    // Start is called before the first frame update
    void Start()
    {
        MaxX = Mathf.Max(Pos1.transform.position.x,Pos2.transform.position.x);
        Minx = Mathf.Min(Pos1.transform.position.x,Pos2.transform.position.x);
        MaxY = Mathf.Max(Pos1.transform.position.y,Pos2.transform.position.y);
        Miny = Mathf.Min(Pos1.transform.position.y,Pos2.transform.position.y);


        float PosX = Random.Range(MaxX, Minx);
        float PosY = Random.Range(MaxY, Miny);

        Instantiate(Respwan[0], new Vector3(PosX, PosY, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
