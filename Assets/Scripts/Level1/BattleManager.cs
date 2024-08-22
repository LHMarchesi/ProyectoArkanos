using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Schema;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;


public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }
   

    private ProgessionTracker progessionTracker;

    [SerializeField] private HealthSistem healthSistem;
    [SerializeField] private SpawnHandler spawnHandler;
    [SerializeField] private BackgroundMove backgroundMove;
    [SerializeField] private ScenesLoader scenesLoader;
    [SerializeField] private UIManager UIManager;
    [SerializeField] private float songTime;
    [SerializeField] private bool levelEnded = false;

    public static int totalpoints { get; private set; }
    public int healtPoints { get; private set; }
    public int pointsRecord { get; private set; }
    public int multiplicator { get; private set; }
    public float timer { get; private set; } = 0;

    private int maxmMultiplicator = 4;

     private void Awake()
    {
        progessionTracker = FindObjectOfType<ProgessionTracker>();
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        Time.timeScale = 1;

        healtPoints = 5;
        multiplicator = 1;
        totalpoints = 0;

        PointsManager(totalpoints);
    }

    void Update()
    {
        if (!levelEnded)
        {
            timer += Time.deltaTime;

            // Solo llama a Win si el nivel no ha terminado
            Win();
            Lose();

            UIManager.UpdateProgessBar(timer, songTime);  // Barra de progreso
            UIManager.UpdateMultiplicator(multiplicator);  // Multiplicador
            UIManager.UpdatePoints(totalpoints);  // Puntos

            spawnHandler.SetLevel(); // Seteo de nivel
            spawnHandler.CircleSpawnhandleer(timer);    // Instancia de enemigos

            backgroundMove.BackgroundSpeedHandleer(timer); // Movimiento del fondo
        }
    }

    public void PointsManager(int points)  // maneja el puntaje y lo muestra en texto
    {
        totalpoints += points;

    }

    public void Win()
    {
        
        if (timer > songTime && !levelEnded) //Cuando el timer, supera el tiempo de la cancion, se invoca el evento OnWin
        {
            levelEnded = true;
            spawnHandler.Spawning(false);
            ScreensManager.Instance.ShowWinScreen();
            
        }
    }

    private void Lose()
    {
        if (healtPoints <= 0 && !levelEnded) //si la vida es menor o igual a 0, pierde y se invoca al evento Onlose
        {
            levelEnded = true;
            ScreensManager.Instance.ShowLoseScreen();
            spawnHandler.Spawning(false);
        }
    }

    public void LostHp() // pierde una vida quita la mitad de puntos
    {
        totalpoints /= 2;
        healtPoints -= 1;
        healthSistem.HpLost(healtPoints);
    }

    public void LostMultiplicator()
    {

        multiplicator = 0;
    }

    public void GainMultiplicator()
    {
        if (multiplicator < maxmMultiplicator)
        {
            multiplicator += 1;
        }
    }
}
