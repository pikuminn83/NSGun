using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class UniqueMagnet : MonoBehaviour
{
    GameObject[] Enemys;
    GameObject player;
    Player playerscript;
    float MoveX;
    float MoveY;
    [SerializeField] private InputActionReference _moveAction;
    [SerializeField] float speed = 3.0f;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject Enemy in Enemys)
        {
            Enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position, this.transform.position, speed * Time.deltaTime);
        }
            time += Time.deltaTime;
            if (time > 5)
            {
                
                Destroy(this.gameObject);
                
            }
            
           
    }

    
}
