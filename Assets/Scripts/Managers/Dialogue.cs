using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    public bool didDialogueStart { get; private set; } = false;
    public bool didDialogueEnd { get; private set; } = false;

    private int lineIndex;
    private float chTime;

    public void StartDialogueSecuence()
    {
        if (!didDialogueStart)
        {
            StartDialogue();
        }
        else if (dialogueText.text == dialogueLines[lineIndex]) // si el texto termino de mostrarse completo
        {
            NextDialogue();
        }

        else // saltear texto
        {
            StopAllCoroutines();
            dialogueText.text = dialogueLines[lineIndex];
        }
    }

    public void EndDialogueSecuence()
    {
        didDialogueEnd = true;
        didDialogueStart = false;
        dialoguePanel.SetActive(false);
    }

    private void StartDialogue()  // Inicia la secuencia de dialogo
    {
        didDialogueStart = true;
        didDialogueEnd = false;
        dialoguePanel.SetActive(true);
        lineIndex = 0;

        StartCoroutine(ShowLine());
    }

    private void NextDialogue() // Secuencia de mostrado de lineas, y desactiva dialogos 
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            EndDialogueSecuence();
        }

    }

    private IEnumerator ShowLine() // muestra letra por letra lo que haya en las lineas de dialogo
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(chTime);
        }
    }

}
