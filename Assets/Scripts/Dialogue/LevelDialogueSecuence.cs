using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDialogueSecuence : MonoBehaviour
{
    [SerializeField] private bool useStartDialogue;
    [SerializeField] private Dialogue onStartDialogue;

    [SerializeField] public bool useWinDialogue;
    [SerializeField] public Dialogue winDialogue;

    [SerializeField] public bool useLoseDialogue;
    [SerializeField] public Dialogue loseDialogue;

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
    public void LoseSequence()
    {
        if (useLoseDialogue && !hasLoseDialogueStarted)
        {
            hasLoseDialogueStarted = true;
            loseDialogue.StartDialogue();
        }

    }
    public void WinSequence()
    {
        if (useWinDialogue && !hasWinDialogueStarted)
        {
            hasWinDialogueStarted = true;
            winDialogue.StartDialogue();
        }
    }
}