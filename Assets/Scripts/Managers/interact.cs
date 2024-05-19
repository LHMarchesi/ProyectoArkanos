using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class interact : MonoBehaviour
{
    private Player player;
    private bool isPlayerOnRange;

    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private Dialogue dialogue;

    private bool isDialogueActive = false;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerOnRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isDialogueActive)
            {
                StartDialogue();

                if (dialogue.didDialogueEnd)
                {
                    EndDialogue();
                    GameManager.Instance.IsEnemy(gameObject);
                }
            }
        }
    }


    private void StartDialogue()
    {
        dialogue.StartDialogueSecuence();
        player.PlayerCanMove(false);
        dialogueMark.SetActive(false);

    }

    private void EndDialogue()
    {
        dialogue.EndDialogueSecuence();
        player.PlayerCanMove(true);
        isDialogueActive = false;
        dialogueMark.SetActive(true);

    }

    private void OnTriggerEnter2D(Collider2D collision) // Triggers para saber si esta dentro del rango
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnRange = true;
            dialogueMark.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnRange = false;
            dialogueMark.SetActive(false);

        }
    }
}


