using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicLibrary : MonoBehaviour
{
    [SerializeField] private AudioClip mainMenuTrack;
    [SerializeField] private AudioClip tutorialLevel;
    [SerializeField] private AudioClip novelTrack;
    [SerializeField] private AudioClip level1Track;
    [SerializeField] private AudioClip level2Track;
    [SerializeField] private AudioClip level3Track;
    [SerializeField] private AudioClip level4Track;

    [SerializeField] public AudioClip currentSfxClip;

    public static MusicLibrary instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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

    public void ManageSongPerLevel(int index)
    {
        AudioClip newTrack = null;
        bool shouldLoop = false;

        switch (index)
        {
            case 0:
                newTrack = mainMenuTrack;
                shouldLoop = true;
                break;
            case 1:
                newTrack = novelTrack;
                break;
            case 2:
                newTrack = tutorialLevel;
                break;
            case 4:
                newTrack = level1Track;
                break;
            case 5:
                newTrack = level2Track;
                break;
            case 6:
                newTrack = level3Track;
                break;
            case 7:
                newTrack = level4Track;
                break;
            default:
                newTrack = mainMenuTrack;
                shouldLoop = true;
                Debug.LogWarning("No music track assigned for this scene index.");
                break;
        }

        AudioManager.instance.PlayMusic(newTrack);
        AudioManager.instance.musicSource.loop = shouldLoop;

    }
}
