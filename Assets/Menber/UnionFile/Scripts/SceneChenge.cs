using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class SceneChenge : MonoBehaviour
{
    [SerializeField] Image fade;
    public bool fadeout = false;
    // Update is called once per frame
    void Update()
    {
        if (fadeout == true)
        {
            fade.color += new Color(0.0f, 0.0f, 0.0f, 0.004f);

            Invoke("ChangeScene", 0.7f);
        }

    }
    public async void StartButton(InputAction.CallbackContext callbackContext)
    {
        fadeout = true;
        //1000‚Åˆê•b
        await Task.Delay(1500);
        SceneManager.LoadScene("UnionMainScene");
    }
    public void RestartButton(InputAction.CallbackContext callbackContext)
    {
        fadeout = true;
        //await Task.Delay(1500);
        SceneManager.LoadScene("UnionTitle");
        
    }
}
