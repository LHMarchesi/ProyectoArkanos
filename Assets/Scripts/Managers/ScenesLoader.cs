using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{
    public static ScenesLoader instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private Animator transitionAnimator;
    [SerializeField] private float transitionTime = 1;


    private void Start()
    {
        transitionAnimator = GetComponentInChildren<Animator>();
    }

    public void RestartScene()
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(SceneLoadByIndex(activeScene));
    } 
    public void LoadScene(string Scene)
    {      
        StartCoroutine(SceneLoadByName(Scene));
    }


    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(SceneLoadByIndex(nextSceneIndex));
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    private IEnumerator SceneLoadByIndex(int index)
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene(index);
    }

    public IEnumerator SceneLoadByName(string sceneName)
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene(sceneName);
    }

    public IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Scene newScene = SceneManager.GetSceneByName(sceneName);
        if (newScene.IsValid())
        {
            SceneManager.SetActiveScene(newScene);
        }
    }


}
