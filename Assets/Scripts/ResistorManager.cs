using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResistorManager : MonoBehaviour
{
    //public GameObject resistorObject;
    public GameObject resistorObject;
    public Sprite[] resistorSprites;

    Dropdown ChangeResistorValue_Dropdown;
    Button ChangeRotation_Button, btn_OK;
    GameObject panel;

    SpriteRenderer ReisitorSpriteRender;
    Transform ResistorRotation;

    private void Awake()
    {
        panel = GameObject.Find("Panel");
        
        ChangeResistorValue_Dropdown = GetComponentsInChildren<Dropdown>()[0];
        ChangeRotation_Button = GetComponentsInChildren<Button>()[0];
        btn_OK = GetComponentsInChildren<Button>()[1];

        ChangeResistorValue_Dropdown.onValueChanged.AddListener(delegate
        {
            ChangeResistor(ChangeResistorValue_Dropdown.value);
        });

        ChangeRotation_Button.onClick.AddListener(delegate
        {
            ChangeResistorRotation();
        });

        btn_OK.onClick.AddListener(delegate
        {
            panel.SetActive(false);
        });

        ChangePanelElements();
        panel.SetActive(false);
    }

    void ChangePanelElements()
    {
        ResistorRotation = resistorObject.transform;
        ReisitorSpriteRender = resistorObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        ChangeResistor(ChangeResistorValue_Dropdown.value);
    }

    void ChangeResistor(int index)
    {
        ReisitorSpriteRender.sprite = resistorSprites[index];
    }

    void ChangeResistorRotation()
    {
        ResistorRotation.transform.eulerAngles = new Vector3(0, 0, ResistorRotation.transform.eulerAngles.z + 90);
    }

    public void PanelShow(bool state)
    {
        ChangePanelElements();
        panel.SetActive(state);
    }
}
