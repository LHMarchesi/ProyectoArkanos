using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using System.ComponentModel.Design;
using System;

public class ScriptReader : MonoBehaviour
{
    private bool isTextDisplaying = true;
    private float chTime = 0.05f;

    private Story _StoryScript;
    public TMP_Text dialogueBox;
    public TMP_Text nameTag;

    public Image characterIcon;
    public Image currentEnemyExpression;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpacePressed();
        }
    }


    public IEnumerator DisplayNextLine()
    {
        if (_StoryScript.canContinue) // Verifica si hay contenido
        {
            dialogueBox.text = string.Empty;
            string text = _StoryScript.Continue(); // Obtiene la siguiente línea
            text = text?.Trim(); // Elimina espacios en blanco

            isTextDisplaying = true; // Indicamos que el texto se está mostrando

            foreach (char ch in text)
            {
                if (!isTextDisplaying) // Si se presiona espacio otra vez, muestra todo el texto
                {
                    dialogueBox.text = text;
                    break;
                }
                dialogueBox.text += ch;
                yield return new WaitForSecondsRealtime(chTime);
            }
            isTextDisplaying = false; // Termina de mostrar el texto
        }
        else
        {
            Console.WriteLine("fin de dialogo");
        }
    }

    public void OnSpacePressed()
    {
        if (isTextDisplaying)
        {
            // Si el texto se está mostrando, setea isTextDisplaying a false para saltear al final
            isTextDisplaying = false;
        }
        else
        {
            // Si no se está mostrando, comienza a mostrar el siguiente texto
            StartCoroutine(DisplayNextLine());
        }
    }


    public void LoadStory(TextAsset _InkJsonFile)
    {
        currentEnemyExpression.gameObject.SetActive(false);
        characterIcon.gameObject.SetActive(false);
        nameTag.gameObject.SetActive(false);

        _StoryScript = new Story(_InkJsonFile.text);
        _StoryScript.BindExternalFunction("Name", (string charName) => ChangeName(charName));
        _StoryScript.BindExternalFunction("CharacterIcon", (string charName) => ChangeCharacterIcon(charName));
        _StoryScript.BindExternalFunction("CharacterExpression", (string expressionName) => ChangeCharacterExpression(expressionName));

        StartCoroutine(DisplayNextLine());

    }

    public void ChangeName(string name)
    {
        nameTag.gameObject.SetActive(true);
        string SpeakerName = name;
        nameTag.text = SpeakerName;
    }

    public void ChangeCharacterIcon(string charName)
    {
        characterIcon.gameObject.SetActive(true);
        characterIcon.sprite = Resources.Load<Sprite>("CharacterIcons/" + charName);
    }

    public void ChangeCharacterExpression(string expressionName)
    {
        currentEnemyExpression.sprite = Resources.Load<Sprite>("EnemysExpression/" + expressionName);
        currentEnemyExpression.gameObject.SetActive(true);
    }


}
