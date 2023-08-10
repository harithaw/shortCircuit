using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManageScript : MonoBehaviour
{

    public BreadBoardManager breadboard;

    public void OnUndoButtonClick()
    {
        breadboard.undo();
    }
}
