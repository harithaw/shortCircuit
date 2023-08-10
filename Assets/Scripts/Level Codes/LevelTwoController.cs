using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoController : MonoBehaviour
{
    public Animator bulbAnimator;
    public Animator switchAnimator;

    public List<bool> lineStates = new List<bool>();
    public bool circuitState = false;
    public void CheckCircuit()
    {
        Debug.Log("Checking circuit...");
        Transform parentTransform = transform;

        if (parentTransform.childCount < 1)
        {
            Debug.Log("Level Failed!");
            return;
        }

        for (int i = 0; i < parentTransform.childCount; i++)
        {
            Transform childTransform = parentTransform.GetChild(i);

            CollisionController cc = childTransform.GetComponent<CollisionController>();

            if (cc != null)
            {
                List<GameObject> contacts = cc.contacts;
                string firstComp = "";
                if (contacts.Count < 2)
                {
                    Debug.Log("Level Failed!");
                    return;
                }

                contacts.ForEach((obj) =>
                {
                    if (firstComp == "")
                    {
                        firstComp = obj.tag;
                    }
                    else
                    {
                        if ((!obj.CompareTag(firstComp)) && (!obj.CompareTag("common")) && (firstComp != "common"))
                        {
                            Debug.Log("Level Failed!");
                            return;
                        }

                        firstComp = obj.tag;
                    }
                    Debug.Log(firstComp);
                });


            }
        }

        bulbAnimator.SetBool("iBulbON", true);
        switchAnimator.SetBool("switchON", true);
        Debug.Log("Level Passed!");
        return;
    }
}
