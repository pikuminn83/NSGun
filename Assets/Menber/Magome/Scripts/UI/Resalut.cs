using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resalut : MonoBehaviour
{
    public TextMeshProUGUI ResultText;
    public TextMeshProUGUI RankText;
    public TextMeshProUGUI ConoboText;

    public int ResulutAreaSS;
    public int ResulutAreaS;
    public int ResulutAreaA;
    public int ResulutAreaB;
    // Start is called before the first frame update
    void Start()
    {
        int resruto = PlayerPrefs.GetInt("SCORE");
        int conbo = PlayerPrefs.GetInt("CONBO");
        ConoboText.text = "MaxCono:" + conbo;
        ResultText.text = "ResultScore:" + resruto;
        if(ResulutAreaSS<=resruto)
        {
            RankText.text = "Rank:" + "SS";
            Debug.Log("SS");
        }
        else if(ResulutAreaS<=resruto)
        {
            RankText.text = "Rank:" + "S";
            Debug.Log("S");
        }
        else if(ResulutAreaA <= resruto)
        {
            RankText.text = "Rank:" + "A";
            Debug.Log("A");
        }
        else if(ResulutAreaB<=resruto)
        {
            RankText.text = "Rank:" + "B";
            Debug.Log("B");
        }
        else
        {
            RankText.text = "Rank:" + "C";
            Debug.Log("C");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
