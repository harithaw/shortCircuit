using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject LevelPassed;
    public GameObject LevelFailed;
    public Animator bulbAnimator;
    public Animator bulb2Animator;
    public Animator switchAnimator;
    public Animator switch2Animator;

    public List<bool> lineStates = new List<bool>();
    public bool circuitState = false;
    public void CheckCircuit()
    {
        Debug.Log("Checking circuit...");
        Transform parentTransform = transform;

        if (parentTransform.childCount < 1)
        {
            LevelFailed.SetActive(true);
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
                if(contacts.Count < 2)
                {
                    LevelFailed.SetActive(true);
                    Debug.Log("Level Failed!");
                    return;
                }

                contacts.ForEach((obj) =>
                {
                    if(firstComp == "")
                    {
                        firstComp = obj.tag;
                    } else
                    {
                        if((!obj.CompareTag(firstComp)) && (!obj.CompareTag("common")) && (firstComp != "common"))
                        {
                            LevelFailed.SetActive(true);
                            Debug.Log("Level Failed!");
                            return;
                        }

                        firstComp = obj.tag;
                    }
                    Debug.Log(firstComp);
                });

                
            }
        }

        if(bulbAnimator != null)
            bulbAnimator.SetBool("iBulbON", true);
        if(switchAnimator != null)
            switchAnimator.SetBool("switchON", true);
        if (bulb2Animator != null)
            bulb2Animator.SetBool("iBulbON", true);
        if (switch2Animator != null)
            switch2Animator.SetBool("switchON", true);
        Debug.Log("Level Passed!");
        LevelPassed.SetActive(true);
        return;
    }

    private void Start()
    {
        LevelPassed.SetActive(false);
        LevelFailed.SetActive(false);
    }
}
