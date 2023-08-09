using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int noOfLevels = 10;
    public Button btnLevel1;

    Button[] btns;

    // Start is called before the first frame update
    void Start()
    {
        btns[0] = btnLevel1;

        for (int i = 1; i < noOfLevels; i++)
        {
            

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToLevel(int levelNo)
    {
        SceneManager.LoadScene(1 + levelNo);
    }
}
