using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject conText;
    public BreadBoardManager breadboard;

    Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = conText.GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (breadboard.AreCellsConnectedExample())
        {
            txt.text = "Connected";
        }
        else
        {
            txt.text = "Not Connected";
        }
    }
}
