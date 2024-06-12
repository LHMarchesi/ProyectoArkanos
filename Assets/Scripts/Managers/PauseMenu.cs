using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauseCanvas;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    private float previusTimeScale = 1;
    private bool isPaused;

    private void Start()
    {
        
        SetVolumeMusic();
        SetVolumeSFX();
        PauseCanvas.SetActive(false);
        isPaused = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        if (Time.timeScale > 0)
        {
            previusTimeScale = Time.timeScale;
            Time.timeScale = 0;
            AudioListener.pause = true;
            PauseCanvas.SetActive(true);
            isPaused = true;
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = previusTimeScale;
            AudioListener.pause = false;
            PauseCanvas.SetActive(false);
            isPaused = false;
        }
    }
   
    public void Resume()
    {
        Time.timeScale = previusTimeScale;
        AudioListener.pause = false;
        PauseCanvas.SetActive(false);
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
