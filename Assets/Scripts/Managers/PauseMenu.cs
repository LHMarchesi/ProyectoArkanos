using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private static bool isPaused;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    private void Start()
    {
        SetVolumeMusic();
        SetVolumeSFX();
        pauseMenu.SetActive(false);
        isPaused = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                
                Resume();
            }else   
            {
                Pause();
            }
        }
    }
        

    private void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        isPaused = true;
    }
    private void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void SetVolumeMusic()
    {
        float volume = musicSlider.value;
        AudioManager.instance.musicSource.volume = volume;
    }


    public void SetVolumeSFX()
    {
        float volume = sfxSlider.value;
        AudioManager.instance.SFXSource.volume = volume;
    }
}
