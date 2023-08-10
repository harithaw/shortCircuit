using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batteryController : MonoBehaviour
{
    public GameObject positive;
    public GameObject negative;

    // Start is called before the first frame update
    void Start()
    {
        positive.tag = "positive";
        negative.tag = "negative";

        Debug.Log(positive.tag);
        Debug.Log(negative.tag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
