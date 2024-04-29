using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private static bool isPaused;

    private void Start()
    {
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
}
