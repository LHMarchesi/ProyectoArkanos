using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLvl2 : MonoBehaviour
{
    private DetectTriggers[] detectTriggers;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject door;

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
                break;
            }
        }
        if (allTrigered)
            door.SetActive(false);
        

        
    }
}
