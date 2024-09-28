using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;


public enum StoryStates
{
    ArkanosGrandpa,
    ArkanosGandalf,
    Level1,
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
        currentLevelIndex = progessionTracker.LoadLevelIndex();
    }

    private void Start()
    {
        UpdateStoryState();
    }

    private void Update()
    {
        if (currentLevelIndex != progessionTracker.LoadLevelIndex()) //Si cambia de estado
        {
            UpdateStoryState();
            currentLevelIndex = progessionTracker.LoadLevelIndex();
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

    private void UpdateStoryState() //Cambia estado segun el index
    {
        switch (progessionTracker.LoadLevelIndex())
        {
            case 0:
                currentState = StoryStates.ArkanosGrandpa;
                break;
            case 1:
                currentState = StoryStates.ArkanosGandalf;
                break;
            case 2:
                SceneManager.LoadScene("LevelTutorial");
                break;
            case 3:
                currentState = StoryStates.Level1;
                break;
            case 4:
                SceneManager.LoadScene("Level1");
                break;
            case 5:
                currentState = StoryStates.Level2;
                break;
            case 6:
                SceneManager.LoadScene("Level2");
                break;
            case 7:
                currentState = StoryStates.Level3;
                break;
            case 8:
                SceneManager.LoadScene("Level3");
                break;
            case 9:
                currentState = StoryStates.Level4;
                break;
            case 10:
                SceneManager.LoadScene("Level4");
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

        director.Play(currentScene);
        StartCoroutine(WaitForTimelineToEnd());
    }

    private void ChangeStoryTo(string levelName) //Cambio de resources
    {
        currentLeveltxt = Resources.Load<TextAsset>("GuionNiveles/" + levelName + "_texto");
        currentBackgroundImg.sprite = Resources.Load<Sprite>("Backround/" + levelName);
        currentScene = Resources.Load<PlayableAsset>("TimeLines/" + levelName + "_Timeline");
    }

    public IEnumerator WaitForTimelineToEnd()
    {
        while (director.time < director.duration)
        {
            scriptReader.currentEnemyExpression.gameObject.SetActive(false);
            scriptReader.dialogueBox.text = string.Empty;
            scriptReader.canPressSpace = false;
            yield return null;
        }
        scriptReader.currentEnemyExpression.gameObject.SetActive(true);
        scriptReader.LoadStory(currentLeveltxt);
        scriptReader.canPressSpace = true;
    }
}
