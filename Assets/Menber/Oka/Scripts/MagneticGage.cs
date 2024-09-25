using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MagneticGage : MonoBehaviour
{

    [SerializeField] GameObject player;
    Player playerscript;
    Image gage;
    

    // Start is called before the first frame update
    void Start()
    {
        gage = GetComponent<Image>();
        playerscript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerscript.Nflag || playerscript.Sflag)
        {

            float a = Time.deltaTime;

            gage.fillAmount += a/5;
        }
        
    }

}
