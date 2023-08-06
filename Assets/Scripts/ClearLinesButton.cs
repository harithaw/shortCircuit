using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearLinesButton : MonoBehaviour
{
    public BreadBoardManager breadboard;


    public void OnClearLinesButtonClick()
    {
        breadboard.clearAllLines();
    }
    
}
