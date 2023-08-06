using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resistor : MonoBehaviour
{
    GameObject ResistorManagerObject;
    public Text txt;

    private void Awake()
    {
        ResistorManagerObject = GameObject.Find("Resistor Manager");
    }

    public void OnClick()
    {
        ResistorManagerObject.GetComponent<ResistorManager>().resistorObject = gameObject;
        txt.text = gameObject.name;
        ResistorManagerObject.GetComponent<ResistorManager>().PanelShow(true);
    }
}
