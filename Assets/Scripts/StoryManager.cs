using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StoryStates
{
    LevelTutorial,
    Level1,
    Level2,
    Level3,
    Level4,
}

public class StoryManager : MonoBehaviour
{

    [SerializeField] private ScriptReader scriptReader;
    public StoryStates currentState;
    public TextAsset currentLeveltxt;
    public Image currentBackgroundImg;
    public Image currentEnemyImg;

    public void Update()
    {
        switch (currentState)
        {
            case StoryStates.LevelTutorial:
                ChangeStoryTo("Level0");
                break;
            case StoryStates.Level1:
                ChangeStoryTo("Level1");
                break;
            case StoryStates.Level2:
                ChangeStoryTo("Level2");
                break;
            case StoryStates.Level3:
                ChangeStoryTo("Level3");
                break;
            case StoryStates.Level4:
                ChangeStoryTo("Level4");
                break;
            default:
                break;
        }
    }

    private void ChangeStoryTo(string levelName)
    {
        currentLeveltxt = Resources.Load<TextAsset>("GuionNiveles/" + levelName + "_texto");
        scriptReader._InkJsonFile = currentLeveltxt;

        currentEnemyImg.sprite = Resources.Load<Sprite>("EnemysOnStorie/" + levelName);
        currentBackgroundImg.sprite = Resources.Load<Sprite>("Backround/" + levelName);
    }

}
