using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class BattleManager : MonoBehaviour
{
    [SerializeField] private HealthSistem healthSistem;
    [SerializeField] private Spawner spawner;
    [SerializeField] private ScenesLoader scenesLoader;
    [SerializeField] private ProgessBar progessBar;

    [SerializeField] private GameObject winingCanvas;
    [SerializeField] private GameObject losingCanvas;

    [SerializeField] private float songTime;

    public static event Action OnLose;
    public static event Action OnWin;

    private int totalpoints;
    private float timer;
    public int healtPoints { get; private set; }

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI pointsTextWinMenu;
    public TextMeshProUGUI pointsTextLoseMenu;

    void Start()
    {
        Time.timeScale = 1;
        healtPoints = 5;

        timer = 0;
        totalpoints = 0;

        winingCanvas.SetActive(false);
        losingCanvas.SetActive(false);

        PointsManager(totalpoints);
    }

    void Update()
    {
        timer += Time.deltaTime;

        Win();
        Lose();

        progessBar.UpdateProgess(timer, songTime);  // Barra de progeso
        spawner.EnemySpawner(timer);  // Instancia de enemigos
    }

    public void PointsManager(int points)  // maneja el puntaje y lo muestra en texto
    {
        totalpoints += points;
        pointsText.text = totalpoints.ToString();
    }

    private void Win()
    {
        if (timer > songTime) //Cuando el timer, supera el tiempo de la cancion, se invoca el evento OnWin, y luego de 5s se muestra la WinScreen
        {
            OnWin?.Invoke();
            spawner.Spawning(false);
            Invoke("ShowWinScreen", 5f);
        }
    }

    private void Lose()
    {
        if (healtPoints <= 0) //si la vida es menor o igual a 0, pierde y se invoca al evento Onlose,  y luego de 5s se muestra la LoseScreen
        {
            OnLose?.Invoke();
            spawner.Spawning(false);
            Invoke("ShowLoseScreen", 5f);
        }
    }

    public void LostHp()
    {
        healtPoints -= 1;
        healthSistem.HpLost(healtPoints);
    }

    private void ShowLoseScreen()
    {
        DialogueSecuence_lvl1.Instance.LoseDialogue.EndDialogueSecuence();
        Time.timeScale = 0;
        pointsTextLoseMenu.text = "Puntos totales : " + totalpoints.ToString();
        losingCanvas.SetActive(true);
    }

    private void ShowWinScreen()
    {
        DialogueSecuence_lvl1.Instance.WinDialogue.EndDialogueSecuence();
        pointsTextWinMenu.text = "Puntos totales : " + totalpoints.ToString();
        Time.timeScale = 0;
        winingCanvas.SetActive(true);
    }

}
