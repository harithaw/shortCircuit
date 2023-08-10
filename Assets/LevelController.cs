using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public List<bool> lineStates = new List<bool>();
    public bool circuitState = false;
    public void CheckCircuit()
    {
        Debug.Log("Checking circuit...");
        Transform parentTransform = transform;
        bool lineState = true;

        for (int i = 0; i < parentTransform.childCount; i++)
        {
            Transform childTransform = parentTransform.GetChild(i);

            CollisionController cc = childTransform.GetComponent<CollisionController>();
            lineState = true;

            if (cc != null)
            {
                List<GameObject> contacts = cc.contacts;
                string firstComp = "";
                contacts.ForEach((obj) =>
                {
                    if(firstComp == "")
                    {
                        firstComp = obj.tag;
                    } else
                    {
                        if((!obj.CompareTag(firstComp)) && (!obj.CompareTag("common")) && (firstComp != "common"))
                        {
                            lineState = false;
                            Debug.Log("Level Failed!");
                            return;
                        }

                        firstComp = obj.tag;
                    }
                    Debug.Log(firstComp);
                });

                
            }
        }

        Debug.Log("Level Passed!");
    }
}
