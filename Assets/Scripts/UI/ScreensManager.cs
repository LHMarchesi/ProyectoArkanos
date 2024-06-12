using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ScreensManager : MonoBehaviour
{
    public static ScreensManager Instance { get; private set; }
    [SerializeField] private GameObject winingCanvas;
    [SerializeField] private GameObject losingCanvas;

    public TextMeshProUGUI pointsTextWinMenu;
    public TextMeshProUGUI pointsRecordText;
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
    }

    public void ShowLoseScreen()
    {
        pointsTextLoseMenu.text = "Puntos totales : " + BattleManager.totalpoints.ToString();
        losingCanvas.SetActive(true);
    }

    public void ShowWinScreen()
    {
        pointsTextWinMenu.text = "Puntos totales : " + BattleManager.totalpoints.ToString();
        int recordPoints = PlayerPrefs.GetInt("RecordPoints", 0);

        if (BattleManager.totalpoints > recordPoints)  // Guardar mejor puntaje
        {
            PlayerPrefs.SetInt("RecordPoints", BattleManager.totalpoints);
            recordPoints = BattleManager.totalpoints;
        }

        pointsRecordText.text = "Best Record: " + recordPoints.ToString();
        pointsTextWinMenu.text = "Puntos totales: " + BattleManager.totalpoints.ToString();

        winingCanvas.SetActive(true);
    }
}
