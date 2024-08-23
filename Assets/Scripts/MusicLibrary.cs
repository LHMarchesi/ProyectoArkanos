using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicLibrary : MonoBehaviour
{
    [SerializeField] private AudioClip mainMenuTrack;
    [SerializeField] private AudioClip novelTrack;
    [SerializeField] private AudioClip level1Track;
    [SerializeField] private AudioClip level2Track;
    [SerializeField] private AudioClip level3Track;
    [SerializeField] private AudioClip level4Track;

    [SerializeField] public AudioClip currentSfxClip;

    private static MusicLibrary instance;

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
        AudioManager.instance.StopMusic();

        switch (index)
        {
            case 0:
                AudioManager.instance.PlayMusic(mainMenuTrack);
                AudioManager.instance.musicSource.loop = true;
                break;
            case 1:
                AudioManager.instance.PlayMusic(novelTrack);
                AudioManager.instance.musicSource.loop = false;
                break;
            case 2:
                AudioManager.instance.PlayMusic(level1Track);
                AudioManager.instance.musicSource.loop = false;
                break;
            case 3:
                AudioManager.instance.PlayMusic(level2Track);
                AudioManager.instance.musicSource.loop = false;
                break;
            case 4:
                AudioManager.instance.PlayMusic(level3Track);
                AudioManager.instance.musicSource.loop = false;
                break;
            case 5:
                AudioManager.instance.PlayMusic(level4Track);
                AudioManager.instance.musicSource.loop = false;
                break;
            case 6:
                AudioManager.instance.PlayMusic(mainMenuTrack);
                AudioManager.instance.musicSource.loop = true;
                break;
            default:
                AudioManager.instance.PlayMusic(mainMenuTrack);
                AudioManager.instance.musicSource.loop = true;
                Debug.LogWarning("No music track assigned for this scene index.");
                break;
        }
    }
}
