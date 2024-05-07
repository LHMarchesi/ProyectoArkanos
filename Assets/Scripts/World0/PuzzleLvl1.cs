using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLvl1 : MonoBehaviour
{
    private Button[] buttonScripts;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject door;

    void Start()
    {
        door.SetActive(true);

        buttonScripts = new Button[buttons.Length];

        for (int i = 0; i < buttons.Length; i++)
        {
            buttonScripts[i] = buttons[i].GetComponent<Button>();
        }
    }
    void Update()
    {
        bool allButtonsPressed = true;

        // Verificar el estado de cada botón
        foreach (Button btnScript in buttonScripts)
        {
            if (!btnScript.IsButtonPress())
            {
                allButtonsPressed = false;
                break;
            }
        }

        if (allButtonsPressed)
        {
            door.SetActive(false);
        } 
    } 


   
}
