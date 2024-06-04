using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLvl2 : MonoBehaviour
{
    private DetectTriggers[] detectTriggers;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject door;
    [SerializeField] private Animator animatorC1;
    [SerializeField] private Animator animatorC2;
    [SerializeField] private Animator animatorC3;

    void Start()
    {
        door.SetActive(true);

        detectTriggers = new DetectTriggers[buttons.Length];

        for (int i = 0; i < buttons.Length; i++)
        {
            detectTriggers[i] = buttons[i].GetComponent<DetectTriggers>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        bool allTrigered = true;
        foreach (DetectTriggers triggerScript in detectTriggers)
        {
            if (!triggerScript.IsTrigered())
            {
                allTrigered = false;
                door.SetActive(true);
                break;
            }
        }
        if (allTrigered)
        {
            door.SetActive(false);
            animatorC1.SetBool("IsConected", true);
            animatorC2.SetBool("IsConected", true);
            animatorC3.SetBool("IsConected", true);
        }
        

        
    }
}
