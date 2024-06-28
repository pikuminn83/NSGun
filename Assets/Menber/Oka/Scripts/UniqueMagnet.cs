using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class UniqueMagnet : MonoBehaviour
{
    GameObject Enemy;
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
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        

    }

    // Update is called once per frame
    void Update()
    {

        
            Enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position, this.transform.position, speed * Time.deltaTime);

            time += Time.deltaTime;
            if (time > 5)
            {
                
                Destroy(this.gameObject);
                
            }
            
           
    }

    
}
