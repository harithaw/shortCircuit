using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnManageScript : MonoBehaviour
{
    public Button b1;
    public DotBoardManager breadboard;

    public void OnUndoButtonClick()
    {
        breadboard.Undo();
    }

    public void GotoSampleScene()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
