using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    
    ScenesLoader scenesLoader;
    //private Player player;
    //[SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    

    //private bool isPlayerOnRange = false;
    private bool didDialogueStart;
    private int lineIndex;
    private float chTime;
        
    [SerializeField, TextArea(4,6)] private string[] dialogueLines;
    private void Start()
    {
        scenesLoader = GameObject.Find("SceneLoadManager").GetComponent<ScenesLoader>();
        //player = GameObject.Find("Player").GetComponent<Player>();

    }

    void Update()
    {
        //if (isPlayerOnRange && Input.GetKeyDown(KeyCode.E)) // si el jugador se encuentra en el rango
        //{
        //    StartDialogueSecuence();
        //}
    }


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
        didDialogueStart = false;
        dialoguePanel.SetActive(false);
    }

    private void StartDialogue()  // Inicia la secuencia de dialogo
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        //dialogueMark.SetActive(false);
        //player.PlayerCanMove(false);
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
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            //dialogueMark.SetActive(true);
            //player.PlayerCanMove(true);
            //GameManager.Instance.IsEnemy(gameObject);
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


   
    //private void OnTriggerEnter2D(Collider2D collision) // Triggers para saber si esta dentro del rango
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        isPlayerOnRange = true;
    //        dialogueMark.SetActive(true);
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        isPlayerOnRange = false;
    //        dialogueMark.SetActive(false);

    //    }
    //}

   
}
