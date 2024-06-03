<<<<<<< HEAD
=======
using System;
>>>>>>> Devv
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreensManager : MonoBehaviour
{
    public static ScreensManager Instance { get; private set; }
    [SerializeField] private GameObject winingCanvas;
    [SerializeField] private GameObject losingCanvas;
    [SerializeField] private GameObject PauseCanvas;

    private float previusTimeScale = 1;
    public static bool isPaused;

    public TextMeshProUGUI pointsTextWinMenu;
<<<<<<< HEAD
=======
    public TextMeshProUGUI pointsRecordText;
>>>>>>> Devv
    public TextMeshProUGUI pointsTextLoseMenu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        winingCanvas.SetActive(false);
        losingCanvas.SetActive(false);
        PauseCanvas.SetActive(false);
<<<<<<< HEAD

=======
>>>>>>> Devv
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    public void ShowLoseScreen()
    {
<<<<<<< HEAD
       // Time.timeScale = 0;
=======
>>>>>>> Devv
        pointsTextLoseMenu.text = "Puntos totales : " + BattleManager.totalpoints.ToString();
        losingCanvas.SetActive(true);
    }

    public void ShowWinScreen()
    {
<<<<<<< HEAD
       // Time.timeScale = 0;
        pointsTextWinMenu.text = "Puntos totales : " + BattleManager.totalpoints.ToString();
=======
        int recordPoints = PlayerPrefs.GetInt("RecordPoints", 0);
        if (BattleManager.totalpoints > recordPoints)  // Guardar mejor puntaje
        {
            PlayerPrefs.SetInt("RecordPoints", BattleManager.totalpoints);
            recordPoints = BattleManager.totalpoints;
        }

        pointsRecordText.text = "Best Record: " + recordPoints.ToString();
        pointsTextWinMenu.text = "Puntos totales: " + BattleManager.totalpoints.ToString();
>>>>>>> Devv
        winingCanvas.SetActive(true);
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
<<<<<<< HEAD
        else if(Time.timeScale == 0)
=======
        else if (Time.timeScale == 0)
>>>>>>> Devv
        {
            Time.timeScale = previusTimeScale;
            AudioListener.pause = false;
            PauseCanvas.SetActive(false);
            isPaused = false;
        }
    }
}
