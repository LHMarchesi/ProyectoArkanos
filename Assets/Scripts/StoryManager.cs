using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using System;
using System.Diagnostics;


public enum StoryStates
{
    ArkanosGrandpa,
    ArkanosGandalf,
    Level2,
    Level3,
    Level4,
}

public class StoryManager : MonoBehaviour
{
    private ProgessionTracker progessionTracker;
  
    [SerializeField] private PlayableAsset currentScene;
    [SerializeField] private TextAsset currentLeveltxt;
    [SerializeField] private Image currentBackgroundImg;
    [SerializeField] private ScriptReader scriptReader;
    [SerializeField] private PlayableDirector director;
    [SerializeField] private StoryStates currentState;
    private int currentLevelIndex;

    private void Awake()
    {
        progessionTracker = FindObjectOfType<ProgessionTracker>();
    }


    private void Start()
    {
        currentLevelIndex = progessionTracker.LevelIndex;
        UpdateStoryState();
    }

    private void Update()
    {
        if (currentLevelIndex != progessionTracker.LevelIndex)
        {
            UpdateStoryState();
            currentLevelIndex = progessionTracker.LevelIndex;
        }
    }
      

    public void LoadNextState(string stateName = null)
    {
        if (!string.IsNullOrEmpty(stateName))
        {
            // Intenta convertir el nombre del estado en un valor del enum
            if (Enum.TryParse(stateName, out StoryStates newState))
            {
                currentState = newState;
            }
        }
        else
        {
            // Si no se pasa un nombre de estado, se avanza al siguiente estado
            if (currentState < StoryStates.Level4) // Verifica que no sobrepase el último estado
            {
                currentState++;
            }
        }
    }

    private void UpdateStoryState()
    {
        progessionTracker.LoadLevelIndex();

        switch (progessionTracker.LevelIndex)
        {
            case 0:
                currentState = StoryStates.ArkanosGrandpa;
                break;
            case 1:
                currentState = StoryStates.ArkanosGandalf;
                break;
            case 2:
                currentState = StoryStates.Level2;
                break;
            case 3:
                currentState = StoryStates.Level3;
                break;
            case 4:
                currentState = StoryStates.Level4;
                break;
            default:
                currentState = StoryStates.ArkanosGrandpa;
                break;
        }

        LoadCurrentStory();
    }

    private void LoadCurrentStory()
    {
        switch (currentState)
        {
            case StoryStates.ArkanosGrandpa:
                ChangeStoryTo("ArkanosGrandpa");
                break;
            case StoryStates.ArkanosGandalf:
                ChangeStoryTo("ArkanosGandalf");
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
        StartCoroutine(WaitForTimelineToEnd());
    }

   

    private void ChangeStoryTo(string levelName)
    {
        currentLeveltxt = Resources.Load<TextAsset>("GuionNiveles/" + levelName + "_texto");
        currentBackgroundImg.sprite = Resources.Load<Sprite>("Backround/" + levelName);
        currentScene = Resources.Load<PlayableAsset>("TimeLines/" + levelName + "_Timeline");
    }

    public IEnumerator WaitForTimelineToEnd()
    {
        while (director.time < director.duration)
        {
            scriptReader.canPressSpace = false;
            yield return null;
        }
        scriptReader.canPressSpace = true;
    }
}
