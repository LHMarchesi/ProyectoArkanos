using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            musicSource = GetComponentInChildren<AudioSource>();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    public AudioSource musicSource;
    public void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip != clip)
        {
            musicSource.Stop();
            musicSource.clip = clip;
            musicSource.Play();
        }
    }

}
