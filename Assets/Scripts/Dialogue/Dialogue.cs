using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    public bool didDialogueStart { get; private set; } = false;
    public bool didDialogueEnd { get; private set; } = false;

    private int lineIndex;
    private float chTime = 0.01f;
    float autoAdvanceTime = 3f;

    private void Update()
    {
        if (!didDialogueStart)
        {
            StartDialogue();
        }
        else if (dialogueText.text == dialogueLines[lineIndex]) // si el texto ha terminado de mostrarse
        {
            NextDialogue();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogueText.text = dialogueLines[lineIndex];
        }
    }

    public void StartDialogue()  // Inicia la secuencia de dialogo
    {
        didDialogueStart = true;
        didDialogueEnd = false;
        dialoguePanel.SetActive(true);
        lineIndex = 0;

        StartCoroutine(ShowLine());
    }
    private IEnumerator ShowLine() // muestra letra por letra lo que haya en las lineas de dialogo
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(chTime);
        }

        StartCoroutine(AutoAdvanceAfterTime());
    }

    private IEnumerator AutoAdvanceAfterTime()
    {
        yield return new WaitForSecondsRealtime(autoAdvanceTime);

        if (dialogueText.text == dialogueLines[lineIndex]) // Asegurarse de que el diálogo haya terminado de mostrarse
        {
            NextDialogue();
        }
    }

    private void NextDialogue() // Secuencia de mostrado de dialogo, y desactiva dialogos al finalizar
    {
        lineIndex++;
        Debug.Log("Next Dialogue Line Index: " + lineIndex);
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()  // Finaliza secuencia de dialogo
    {
        didDialogueEnd = true;
        didDialogueStart = false;
        dialoguePanel.SetActive(false);
        Debug.Log("End of Dialogue Sequence"); // Depuración
    }
}
