using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicLibrary : MonoBehaviour
{
    [SerializeField] private AudioClip mainMenuTrack;
    [SerializeField] private AudioClip level1Track;
    [SerializeField] private AudioClip level2Track;
    [SerializeField] private AudioClip level3Track;
    [SerializeField] private AudioClip level4Track;
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MusicLibrary");

        if (objs.Length > 1)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ManageSongPerLevel(scene.buildIndex);
    }

    private void ManageSongPerLevel(int index)
    {
        switch (index)
        {
            case 0:
                AudioManager.instance.PlayMusic(mainMenuTrack);
                break;
            case 1:
                AudioManager.instance.PlayMusic(level1Track);
                break;
            case 2:
                AudioManager.instance.PlayMusic(level2Track);
                break;
            case 3:
                AudioManager.instance.PlayMusic(level3Track);
                break; 
            case 4:
                AudioManager.instance.PlayMusic(level4Track);
                break;
            default:
                Debug.LogWarning("No music track assigned for this scene index.");
                break;
        }
    }
}
