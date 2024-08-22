using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Volume Sliders")]
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // Initialize AudioSources
            musicSource = GetComponentsInChildren<AudioSource>()[0];
            sfxSource = GetComponentsInChildren<AudioSource>()[1];

            // Load saved volume levels
            ManageVolume();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        VolumeHandler();
        // Continuously update volume based on slider values
        if (musicSlider != null)
            musicSource.volume = musicSlider.value;

        if (sfxSlider != null)
            sfxSource.volume = sfxSlider.value;
    }

    public void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip != clip)
        {
            musicSource.clip = clip;
            musicSource.time = 0;
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    public void ChangeMusicVolume(float volume)
    {
        musicSource.volume = volume;
        SaveMusicVolume();
    }

    public void ChangeSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        SaveSFXVolume();
    }

    private void VolumeHandler()
    {
        GameObject musicSliderObject = GameObject.FindGameObjectWithTag("MusicSlider");
        GameObject sfxSliderObject = GameObject.FindGameObjectWithTag("SFXSlider");

        if (musicSliderObject != null)
        {
            musicSlider = musicSliderObject.GetComponent<Slider>();

            if (PlayerPrefs.HasKey("MusicVolume"))
            {
                float savedVolume = PlayerPrefs.GetFloat("MusicVolume");
                musicSlider.value = savedVolume;
                musicSource.volume = savedVolume;
            }
            else
            {
                PlayerPrefs.SetFloat("MusicVolume", .6f);
                musicSlider.value = .6f;
                musicSource.volume = .6f;
            }

            musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        }

        if (sfxSliderObject != null)
        {
            sfxSlider = sfxSliderObject.GetComponent<Slider>();

            if (PlayerPrefs.HasKey("SFXVolume"))
            {
                float savedVolume = PlayerPrefs.GetFloat("SFXVolume");
                sfxSlider.value = savedVolume;
                sfxSource.volume = savedVolume;
            }
            else
            {
                PlayerPrefs.SetFloat("SFXVolume", .6f);
                sfxSlider.value = .6f;
                sfxSource.volume = .6f;
            }

            sfxSlider.onValueChanged.AddListener(ChangeSFXVolume);
        }
    }

    private void ManageVolume()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 0.6f);
        }

        if (!PlayerPrefs.HasKey("SFXVolume"))
        {
            PlayerPrefs.SetFloat("SFXVolume", 0.6f);
        }

        LoadMusicVolume();
        LoadSFXVolume();
    }

    private void LoadMusicVolume()
    {
        musicSource.volume = PlayerPrefs.GetFloat("MusicVolume");
    }

    private void SaveMusicVolume()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }

    private void LoadSFXVolume()
    {
        sfxSource.volume = PlayerPrefs.GetFloat("SFXVolume");
    }

    private void SaveSFXVolume()
    {
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
    }
}