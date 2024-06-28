using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSystem : MonoBehaviour
{
    //[SerializeField, Header("�ړ����x")]
    //private float PlayerSpeed = 1.0f;

    private Vector3 _velocity;

    public void OnMove(InputAction.CallbackContext context)
    {
        // MoveAction�̓��͒l���擾
        var axis = context.ReadValue<Vector2>();

        // �ړ����x��ێ�
        _velocity = new Vector3(axis.x,axis.y,0);
        Debug.Log("S");
        
    }
    private void Update()
    {
        // �I�u�W�F�N�g�ړ�
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
