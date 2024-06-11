using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class interact : MonoBehaviour
{
    private Player player;
    private bool isPlayerOnRange;
    [SerializeField] private bool changeScene;
    [SerializeField] private string goToScene;
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private Dialogue dialogue;

    private bool isDialogueActive = false;

    void Start()
    {
        dialogueMark.SetActive(false);
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerOnRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isDialogueActive)
            {
                dialogue.StartDialogueSecuence();

                if (dialogue.didDialogueEnd)
                {
                    dialogue.EndDialogueSecuence();
                    if (changeScene)
                    {
                        ScenesLoader.instance.LoadScene(goToScene);
                    }
                }
            }
        }
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


