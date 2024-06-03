using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSecuence_lvl1 : MonoBehaviour
{
    public static DialogueSecuence_lvl1 Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    Circle circleScript;
    Circle circleScript2;

    [SerializeField] GameObject circlePrefab;
    [SerializeField] GameObject circlePrefab2;

    [SerializeField] private Dialogue firstdialogue;
    [SerializeField] private Dialogue secondDialogue;
    [SerializeField] private Dialogue thirdDialogue;
    [SerializeField] private Dialogue fourthDialogue;
    [SerializeField] public Dialogue WinDialogue;
    [SerializeField] public Dialogue LoseDialogue;

    private bool hasSecondDialogueStarted = false;
    private bool hasThirdDialogueStarted = false;
    private bool hasFourthDialogueStarted = false;
    public bool hasLoseDialogueStarted = false;
    public bool hasWinDialogueStarted = false;


    void Start()
    {
        circleScript = circlePrefab.GetComponent<Circle>();
        circleScript2 = circlePrefab2.GetComponent<Circle>();

        circlePrefab.SetActive(false);
        circlePrefab2.SetActive(false);

        StartCoroutine(FirstDialogue());

        BattleManager.OnLose += LoseSequence;
        BattleManager.OnWin += WinSequence;

    }
    void Update()
    {
        if (circleScript.destroy && !hasSecondDialogueStarted)
        {
            StartSecondDialogue();
        }

        if (circleScript2.hitIn && !hasFourthDialogueStarted)
        {
            StartEasterEggSequence();
        }

        if (circleScript2.destroy && !hasThirdDialogueStarted && !hasFourthDialogueStarted)
        {
            StartThirdDialogue();
        }

    }

    private IEnumerator FirstDialogue()
    {
        yield return new WaitForSeconds(.5f);
        firstdialogue.StartDialogueSecuence();

        yield return new WaitForSeconds(2);
        circlePrefab.SetActive(true);
    }

    private void StartSecondDialogue()
    {
        hasSecondDialogueStarted = true;

        firstdialogue.EndDialogueSecuence();
        StopAllCoroutines();

        StartCoroutine(DelayedAction(1f, () =>
        {
            secondDialogue.StartDialogueSecuence();
            circlePrefab2.SetActive(true);
        }));

    }
    private void StartThirdDialogue()
    {
        hasThirdDialogueStarted = true;
        secondDialogue.EndDialogueSecuence();

        StartCoroutine(DelayedAction(1f, () => thirdDialogue.StartDialogueSecuence()));
        StartCoroutine(DelayedAction(3f, () => thirdDialogue.EndDialogueSecuence()));
    }
   
    private void StartEasterEggSequence()
    {
        hasFourthDialogueStarted = true;
        secondDialogue.EndDialogueSecuence();
        fourthDialogue.StartDialogueSecuence();

        StartCoroutine(DelayedAction(1f, () => fourthDialogue.EndDialogueSecuence()));
    }

    private void LoseSequence()
    {
        if (!hasLoseDialogueStarted)
        {
            hasLoseDialogueStarted = true;
            LoseDialogue.StartDialogueSecuence();
            StartCoroutine(DelayedAction(5f, () => LoseDialogue.EndDialogueSecuence()));
            StartCoroutine(DelayedAction(5f, () => ScreensManager.Instance.ShowLoseScreen()));
        }

    }
    private void WinSequence()
    {
        if (!hasWinDialogueStarted)
        {
            hasWinDialogueStarted = true;
            WinDialogue.StartDialogueSecuence();
            StartCoroutine(DelayedAction(5f, () => WinDialogue.EndDialogueSecuence()));
            StartCoroutine(DelayedAction(5f, () => ScreensManager.Instance.ShowWinScreen()));
        }
    }
    private IEnumerator DelayedAction(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }

    private void OnDestroy()
    {
        BattleManager.OnLose -= LoseSequence;
        BattleManager.OnWin -= WinSequence;
    }
}