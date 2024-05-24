using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class TitleButton : MonoBehaviour
{

        
    public void StartButton(InputAction.CallbackContext context)
    {

        SceneManager.LoadScene("MainGame");
    }
    public void EndButton()
    {

    }
}
