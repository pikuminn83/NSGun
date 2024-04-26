using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSystem : MonoBehaviour
{
    [SerializeField, Header("ˆÚ“®‘¬“x")]
    private float PlayerSpeed = 1.0f;

    
    public void Move(InputAction.CallbackContext context)
    {
        Debug.Log("S");
        
    }
    public void Attack(InputAction.CallbackContext context)
    {
            Debug.Log("3");
        
       
    }
    public void Special(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("1");
        }
    }

}
