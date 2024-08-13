using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource musicSource;
    public Slider musicSlider;

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

    private void Update()
    {
        VolumeHandleer();
    }

    public void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip != clip)
        {
            musicSource.clip = clip;
        }
        musicSource.time = 0;
        musicSource.Play();
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void ChangeMusicVolume(float volume)
    {
        AudioListener.volume = volume;
        SaveMusicLevel();
    }

    private void VolumeHandleer()
    {
        GameObject sliderObject = GameObject.FindGameObjectWithTag("MusicSlider");
        if (sliderObject != null)
        {
            musicSlider = sliderObject.GetComponent<Slider>();

            if (PlayerPrefs.HasKey("MusicVolume"))
            {
                float savedVolume = PlayerPrefs.GetFloat("MusicVolume");
                musicSlider.value = savedVolume;
                AudioListener.volume = savedVolume;
            }
            else
            {
                PlayerPrefs.SetFloat("MusicVolume", .6f);
                musicSlider.value = .6f;
                AudioListener.volume = .6f;
            }

            musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        }
    }

    private void ManageVolume()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1);
            LoadMusicLevel();
        }
        else
        {
            LoadMusicLevel();
        }
    }

    private void LoadMusicLevel() { AudioListener.volume = PlayerPrefs.GetFloat("MusicVolume"); }
    private void SaveMusicLevel() { PlayerPrefs.SetFloat("MusicVolume", musicSlider.value); }
}
