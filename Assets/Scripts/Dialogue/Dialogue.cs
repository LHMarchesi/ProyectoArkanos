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
    private void NextDialogue() // Secuencia de mostrado de dialogo, y desactiva dialogos al finalizar
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

    public void EndDialogueSecuence()  // Finaliza secuencia de dialogo
    {
        didDialogueEnd = true;
        didDialogueStart = false;
        dialoguePanel.SetActive(false);
        PlayerMove(true);
    }

    private void StartDialogue()  // Inicia la secuencia de dialogo
    {
        PlayerMove(false);
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
    }

    public IEnumerator ShowDialogue(Dialogue dialogue, float duration,Action onComplete)
    {
        dialogue.StartDialogueSecuence();
        yield return new WaitForSecondsRealtime(duration); // Espera la duración del diálogo
        dialogue.EndDialogueSecuence();
        onComplete?.Invoke(); // Llama al callback después de que el diálogo ha terminado
    }

    private void PlayerMove(bool canMove)
    {
        Player player = FindObjectOfType<Player>();

        if (player != null)
        {
            player.PlayerCanMove(canMove);
        }
    }
}
