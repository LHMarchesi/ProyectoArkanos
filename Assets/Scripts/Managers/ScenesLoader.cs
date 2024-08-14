using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{
    public static ScenesLoader instance;
    private Animator transitionAnimator;
    private MusicLibrary musicLibrary;
    [SerializeField] private float transitionTime = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            transitionAnimator = GetComponentInChildren<Animator>();
            musicLibrary = FindObjectOfType<MusicLibrary>();

            if (musicLibrary == null)
            {
                Debug.LogError("No se encontró MusicLibrary en la escena.");
            }

        }
    }

    public void LoadScene(string Scene)
    {
        StartCoroutine(SceneLoadByName(Scene));
    }

    private IEnumerator SceneLoadByName(string sceneName)
    {
        transitionAnimator.SetTrigger("StartTransition");
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(transitionTime);
        SceneManager.LoadScene(sceneName);
        AudioListener.pause = false;
      
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
