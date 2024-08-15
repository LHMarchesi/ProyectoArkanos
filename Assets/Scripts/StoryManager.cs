using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;


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

    private StoryStates previousState;
    [SerializeField] private ScriptReader scriptReader;
    [SerializeField] private PlayableDirector director;
    public StoryStates currentState;
    public PlayableAsset currentScene;
    public TextAsset currentLeveltxt;
    public Image currentBackgroundImg;

    void Start()
    {
        previousState = currentState;
        LoadCurrentStory();
    }

    void Update()
    {
        if (currentState != previousState)
        {
            LoadCurrentStory();
            previousState = currentState;
        }
    }

    private void LoadCurrentStory()
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
        scriptReader.LoadStory(currentLeveltxt);
        director.Play(currentScene);

    }
    private void ChangeStoryTo(string levelName)
    {
        currentLeveltxt = Resources.Load<TextAsset>("GuionNiveles/" + levelName + "_texto");
        currentBackgroundImg.sprite = Resources.Load<Sprite>("Backround/" + levelName);
        currentScene= Resources.Load<PlayableAsset>("TimeLines/" + levelName + "_Timeline");
    }

}
