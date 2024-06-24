using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }
    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
    }

    [SerializeField] private HealthSistem healthSistem;
    [SerializeField] private SpawnHandler spawnHandler;
    [SerializeField] private BackgroundMove backgroundMove;
    [SerializeField] private ScenesLoader scenesLoader;
    [SerializeField] private UIManager UIManager;
    [SerializeField] private float songTime;
    [SerializeField] private bool levelEnded = false;

    public static event Action OnLose;
    public static event Action OnWin;

    public static int totalpoints { get; private set; }
    public int healtPoints { get; private set; }
    public int pointsRecord { get; private set; }
    public int multiplicator { get; private set; }
    public float timer { get; private set; } = 0;

    private int maxmMultiplicator = 4;

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
        }

        Win();
        Lose();

        UIManager.UpdateProgessBar(timer, songTime);  // Barra de progeso
        UIManager.UpdateMultiplicator(multiplicator);  // Multiplicador
        UIManager.UpdatePoints(totalpoints);  // Points

        spawnHandler.SetLevel(); // Seteo de nivel
        spawnHandler.CircleSpawnhandleer(timer);    // Instancia de enemigos
    
        backgroundMove.BackgroundSpeedHandleer(timer); // Movimiento del fondo
    }

    public void PointsManager(int points)  // maneja el puntaje y lo muestra en texto
    {
        totalpoints += points;

    }

    private void Win()
    {
        if (timer > songTime) //Cuando el timer, supera el tiempo de la cancion, se invoca el evento OnWin
        {
            OnWin?.Invoke();
            levelEnded = true;
            spawnHandler.Spawning(false);
        }
    }

    private void Lose()
    {
        if (healtPoints <= 0) //si la vida es menor o igual a 0, pierde y se invoca al evento Onlose
        {
            OnLose?.Invoke();
            levelEnded = true;
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

    private void OnDestroy()
    {
        OnLose -= ScreensManager.Instance.ShowLoseScreen;
        OnWin -= ScreensManager.Instance.ShowWinScreen;
    }
}
