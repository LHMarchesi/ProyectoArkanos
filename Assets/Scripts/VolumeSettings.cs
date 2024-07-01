using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    //[SerializeField] Slider sfxSlider;

    void Start()
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

    public void ChangeMusicVolume(float volume)
    {
        AudioListener.volume = volume;
        SaveMusicLevel();
    }

    private void LoadMusicLevel() { AudioListener.volume = PlayerPrefs.GetFloat("MusicVolume"); }
    private void SaveMusicLevel() { PlayerPrefs.SetFloat("MusicVolume", musicSlider.value); }
}
