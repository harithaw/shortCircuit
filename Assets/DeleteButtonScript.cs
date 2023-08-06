using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButtonScript : MonoBehaviour
{

    public BreadBoardManager breadboard;

    public void OnDeleteButtonClick()
    {
        breadboard.deleteSelectedLine();
    }
}
