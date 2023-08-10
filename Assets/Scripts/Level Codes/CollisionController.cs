using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public bool lineState = false;
    public List<GameObject> contacts = new List<GameObject>();

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision occured: " + collision.gameObject.tag);
        if(!contacts.Contains(collision.gameObject))
        {
            contacts.Add(collision.gameObject);
        }
        if(!collision.gameObject.CompareTag("line") && gameObject.tag == "line")
        {
            gameObject.tag = collision.gameObject.tag;
        }
    }
}
