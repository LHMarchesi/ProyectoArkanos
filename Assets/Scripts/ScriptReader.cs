using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;

public class ScriptReader : MonoBehaviour
{

    private Story _StoryScript;

    public TMP_Text dialogueBox;
    public TMP_Text nameTag;

    public Image characterIcon;
    public Image currentEnemyExpression;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextLine();
        }
    }

    public void LoadStory(TextAsset _InkJsonFile)
    {
        _StoryScript = new Story(_InkJsonFile.text);
        _StoryScript.BindExternalFunction("Name", (string charName) => ChangeName(charName));
        _StoryScript.BindExternalFunction("CharacterIcon", (string charName) => ChangeCharacterIcon(charName));
        _StoryScript.BindExternalFunction("CharacterExpression", (string expressionName) => ChangeCharacterExpression(expressionName));

        DisplayNextLine();

    }

    public void DisplayNextLine()
    {
        if (_StoryScript.canContinue) // Checking if there is content to go through
        {
            string text = _StoryScript.Continue(); //Gets Next Line
            text = text?.Trim(); //Removes White space from the text
            dialogueBox.text = text; //Displays new text
        }
        else
        {

        }
    }

    public void ChangeName(string name)
    {
        string SpeakerName = name;

        nameTag.text = SpeakerName;
    }

    public void ChangeCharacterIcon(string charName)
    {
        characterIcon.sprite = Resources.Load<Sprite>("CharacterIcons/" + charName);
    }  
    
    public void ChangeCharacterExpression(string expressionName)
    {
        currentEnemyExpression.sprite = Resources.Load<Sprite>("EnemysExpression/" + expressionName);
    }


}
