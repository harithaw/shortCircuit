using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iBulbController : MonoBehaviour
{
    public GameObject com1;
    public GameObject com2;

    // Start is called before the first frame update
    void Start()
    {
        com1.tag = "common";
        com2.tag = "common";

        Debug.Log(com1.tag);
        Debug.Log(com2.tag);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision occurred with: " + collision.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
