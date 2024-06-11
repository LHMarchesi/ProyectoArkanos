using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLevelSecuence : MonoBehaviour
{

    [SerializeField] GameObject circlePrefab;
    [SerializeField] GameObject circlePrefab2;

    Circle circleScript;
    Circle circleScript2;

    [SerializeField] private Dialogue firstDialogue;
    [SerializeField] private Dialogue secondDialogue;
    [SerializeField] private Dialogue thirdDialogue;
    [SerializeField] private Dialogue fourthDialogue;

    private bool hasSecondDialogueStarted;
    private bool hasFourthDialogueStarted;
    private bool hasThirdDialogueStarted;

    private void Start()
    {
        circleScript = circlePrefab.GetComponent<Circle>();
        circleScript2 = circlePrefab2.GetComponent<Circle>();

        circlePrefab.SetActive(false);
        circlePrefab2.SetActive(false);

        StartSecuence();
    }


    private void Update()
    {
        if (circleScript.destroy && !hasSecondDialogueStarted)
        {
            StartSecondDialogue();
        }

        if (circleScript2.hitIn && !hasFourthDialogueStarted)
        {
            StartFourthDialogue();
        }

        if (circleScript2.destroy && !hasThirdDialogueStarted && !hasFourthDialogueStarted)
        {
            StartThirdDialogue();
        }

    }
    private void StartSecuence()
    {
        firstDialogue.StartDialogueSecuence();
        StartCoroutine(DelayedAction(2f, ()=> circlePrefab.SetActive(true)));
        StartCoroutine(DelayedAction(4f, () => firstDialogue.EndDialogueSecuence()));
    }

    private void StartSecondDialogue()
    {
        hasSecondDialogueStarted = true;
        secondDialogue.StartDialogueSecuence();

        StartCoroutine(DelayedAction(1f, () => circlePrefab2.SetActive(true)));
        StartCoroutine(DelayedAction(3f, () => secondDialogue.EndDialogueSecuence()));
    }

    private void StartThirdDialogue()
    {
        hasThirdDialogueStarted = true;
        thirdDialogue.StartDialogueSecuence();
        
        StartCoroutine(DelayedAction(4f, () => thirdDialogue.EndDialogueSecuence()));
    }
    private void StartFourthDialogue()
    {
        hasFourthDialogueStarted = true;
        fourthDialogue.StartDialogueSecuence();
        
        StartCoroutine(DelayedAction(1f, () => fourthDialogue.EndDialogueSecuence()));
    }


    private IEnumerator DelayedAction(float delay, Action action)
    {
        yield return new WaitForSecondsRealtime(delay);
        action?.Invoke();
    }

}
