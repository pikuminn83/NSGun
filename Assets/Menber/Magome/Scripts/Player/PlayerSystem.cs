using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSystem : MonoBehaviour
{
    //[SerializeField, Header("移動速度")]
    //private float PlayerSpeed = 1.0f;

    private Vector3 _velocity;

    public void OnMove(InputAction.CallbackContext context)
    {
        // MoveActionの入力値を取得
        var axis = context.ReadValue<Vector2>();

        // 移動速度を保持
        _velocity = new Vector3(axis.x,axis.y,0);
        Debug.Log("S");
        
    }
    private void Update()
    {
        // オブジェクト移動
        transform.position += _velocity * Time.deltaTime;
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
