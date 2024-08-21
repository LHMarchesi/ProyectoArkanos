using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDialogueSecuence : MonoBehaviour
{
    [SerializeField] private bool useStartDialogue;
    [SerializeField] private bool useWinDialogue;
    [SerializeField] private bool useLoseDialogue;

    [SerializeField] private float startDialogueDuration;   
    [SerializeField] private float winDialogueDuration = 3;   
    [SerializeField] private float loseDialogueDuration = 3;   

    [SerializeField] private Dialogue startDialogue;
    [SerializeField] private Dialogue winDialogue;
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
            StartCoroutine(startDialogue.ShowDialogue(startDialogue, startDialogueDuration, () => startDialogue.EndDialogueSecuence()));

        }
    }
    private void LoseSequence()
    {
        if (useLoseDialogue && !hasLoseDialogueStarted)
        {
            hasLoseDialogueStarted = true;
            StartCoroutine(loseDialogue.ShowDialogue(loseDialogue, winDialogueDuration, () =>  ScreensManager.Instance.ShowLoseScreen()));
        }

    }
    private void WinSequence()
    {
        if (useWinDialogue && !hasWinDialogueStarted)
        {
            hasWinDialogueStarted = true;
            StartCoroutine(winDialogue.ShowDialogue(winDialogue, loseDialogueDuration, () => ScreensManager.Instance.ShowWinScreen()));

        }
    }
}