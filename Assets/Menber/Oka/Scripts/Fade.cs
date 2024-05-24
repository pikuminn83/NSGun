using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Fade : MonoBehaviour
{
    [SerializeField] Image fade;
    public bool fadeout = false;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeout==true)
        {
            fade.color += new Color(0.0f, 0.0f, 0.0f, 0.004f);

            Invoke("ChangeScene",0.7f);
        }

    }
    private void ChangeScene()
    {
        SceneManager.LoadScene("Scene");
    }
    public void PushButton()
    {
        fadeout = true;
    }

}
