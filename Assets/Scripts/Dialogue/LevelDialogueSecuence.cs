using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDialogueSecuence : MonoBehaviour
{
    [SerializeField] private bool useStartDialogue;
    [SerializeField] private Dialogue onStartDialogue;

    [SerializeField] private bool useWinDialogue;
    [SerializeField] private Dialogue winDialogue;

    [SerializeField] private bool useLoseDialogue;
    [SerializeField] private Dialogue loseDialogue;

    private bool hasWinDialogueStarted;
    private bool hasLoseDialogueStarted;
    private bool hasStartDialogueStarted;


    void Start()
    {
        StartSequence();
    }

    private void StartSequence()
    {
        if (useStartDialogue  && !hasStartDialogueStarted)
        {
            hasStartDialogueStarted = true;
            onStartDialogue.StartDialogue();
        }
    }
    private void LoseSequence()
    {
        if (useLoseDialogue && !hasLoseDialogueStarted)
        {
            hasLoseDialogueStarted = true;
            //StartCoroutine(loseDialogue.ShowDialogue(loseDialogue, winDialogueDuration, () =>  ScreensManager.Instance.ShowLoseScreen()));
        }

    }
    private void WinSequence()
    {
        if (useWinDialogue && !hasWinDialogueStarted)
        {
            hasWinDialogueStarted = true;
          //  StartCoroutine(winDialogue.ShowDialogue(winDialogue, loseDialogueDuration, () => ScreensManager.Instance.ShowWinScreen()));

        }
    }
}