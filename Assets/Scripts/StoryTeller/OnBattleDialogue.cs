using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBattleDialogue : MonoBehaviour
{
    [SerializeField] private bool dialogueOnStart;
    [SerializeField] private string startDialogue;
    [SerializeField] private TextAsset currentLeveltxt;
    [SerializeField] private ScriptReader scriptReader;

   
    void Start()
    {
        if (dialogueOnStart)
        {
            ChangeDialogueTo(startDialogue);
            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ChangeDialogueTo(string dialogue) //Cambio de resources
    {
        currentLeveltxt = Resources.Load<TextAsset>("GuionNiveles/" + dialogue + "_texto");
        scriptReader.LoadStory(currentLeveltxt);
        scriptReader.canPressSpace = true;
    }
}
