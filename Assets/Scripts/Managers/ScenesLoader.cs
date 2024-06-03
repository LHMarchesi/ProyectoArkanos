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
    public void SceneLoader(string sceneName)
    {
        StartCoroutine(SceneLoadByName(sceneName));
    }

    public void RestartScene()
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(SceneLoad(activeScene));
    }


    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(SceneLoad(nextSceneIndex));
        
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    private IEnumerator SceneLoad(int sceneIndex)
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }

    public IEnumerator SceneLoadByName(string sceneName)
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene(sceneName);
    }


}
