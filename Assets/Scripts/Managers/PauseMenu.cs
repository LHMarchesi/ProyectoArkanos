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

    private bool isPaused;

    private void Start()
    {
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
            Time.timeScale = 0;
            AudioListener.pause = true;
            PauseCanvas.SetActive(true);
            isPaused = true;
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            PauseCanvas.SetActive(false);
            isPaused = false;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        PauseCanvas.SetActive(false);
        isPaused = false;
    }
}
