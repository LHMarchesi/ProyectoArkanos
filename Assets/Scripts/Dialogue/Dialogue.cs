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

    private bool didDialogueEnd;
    private bool didDialogueStart;
    private int lineIndex;
    private float chTime = 0.01f;
    float autoAdvanceTime = 5f;
    private bool isShowingLine = false; 

    public bool DidDialogueEnd { get => didDialogueEnd; set => didDialogueEnd = value; }
    public bool DidDialogueStart { get => didDialogueStart; set => didDialogueStart = value; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !DidDialogueEnd)
        {
            if (isShowingLine)
            {
                StopAllCoroutines(); 
                dialogueText.text = dialogueLines[lineIndex]; // Muestra todo el texto
                isShowingLine = false; 
            }
            else if (dialogueText.text == dialogueLines[lineIndex]) // Si ya se mostró todo el texto, pasa a la siguiente línea
            {
                NextDialogue();
            }
        }
    }

    public void StartDialogue()  // Inicia la secuencia de dialogo
    {
        DidDialogueStart = true;
        DidDialogueEnd = false;
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
        StopAllCoroutines();
        DidDialogueEnd = true;
        DidDialogueStart = false;
        dialoguePanel.SetActive(false);
    }
}
