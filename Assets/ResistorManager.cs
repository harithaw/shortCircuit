using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResistorManager : MonoBehaviour
{
    public GameObject resistorObj;
    public Sprite[] resistorSprites;

    Dropdown ChangeResistor_Dropdown;
    SpriteRenderer ReisitorSpriteRender;

    void Start()
    {
        ChangeResistor_Dropdown = GetComponentsInChildren<Dropdown>()[0];
        ReisitorSpriteRender = resistorObj.GetComponent<SpriteRenderer>();

        ChangeResistor_Dropdown.onValueChanged.AddListener(delegate {
            ChangeResistor(ChangeResistor_Dropdown.value);
        });

        ChangeResistor(ChangeResistor_Dropdown.value);
    }

    void Update()
    {
        
    }

    void ChangeResistor(int index)
    {
        ReisitorSpriteRender.sprite = resistorSprites[index];
    }
}
