using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLvl1 : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject door;
    [SerializeField] private Button button;
    private Button[] buttonScripts;
   

    void Start()
    {
        door.SetActive(true);

        buttonScripts = new Button[buttons.Length];

        for (int i = 0; i < buttons.Length; i++)
        {
            buttonScripts[i] = buttons[i].GetComponent<Button>();
        }
    }

    // Update is called once per frame
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
