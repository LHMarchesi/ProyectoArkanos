using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDialogueSecuence : MonoBehaviour
{
    [SerializeField] private bool useStartDialogue = true;
    [SerializeField] private bool useWinDialogue = true;
    [SerializeField] private bool useLoseDialogue = true;

    [SerializeField] private Dialogue startDialogue;
    [SerializeField] private Dialogue winDialogue;
    [SerializeField] private Dialogue loseDialogue;

    private bool hasWinDialogueStarted;
    private bool hasLoseDialogueStarted;
    private bool hasStartDialogueStarted;


    void Start()
    {
        StartSequence();

        BattleManager.OnLose += LoseSequence;
        BattleManager.OnWin += WinSequence;
    }

    private void StartSequence()
    {
        if (useStartDialogue  && !hasStartDialogueStarted)
        {
            hasStartDialogueStarted = true;
            StartCoroutine(startDialogue.ShowDialogue(startDialogue,3f, () => startDialogue.EndDialogueSecuence()));

        }
    }
    private void LoseSequence()
    {
        if (useLoseDialogue && !hasLoseDialogueStarted)
        {
            hasLoseDialogueStarted = true;
            StartCoroutine(loseDialogue.ShowDialogue(loseDialogue, 3f, () =>  ScreensManager.Instance.ShowLoseScreen()));
        }

    }
    private void WinSequence()
    {
        if (useWinDialogue && !hasWinDialogueStarted)
        {
            hasWinDialogueStarted = true;
            StartCoroutine(winDialogue.ShowDialogue(winDialogue, 3f, () => ScreensManager.Instance.ShowWinScreen()));

        }
    }
    
    private void OnDestroy()
    {
        BattleManager.OnLose -= LoseSequence;
        BattleManager.OnWin -= WinSequence;
    }
}