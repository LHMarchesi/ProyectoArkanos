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
    [SerializeField] private LevelMapping levelMapping;
    [SerializeField] private ScenesLoader scenesLoader;
    [SerializeField] private UIManager UIManager;
    [SerializeField] private float songTime;
    [SerializeField] private bool levelEnded = false;

    public static event Action OnLose;
    public static event Action OnWin;

    private float timer = 0;
    public static int totalpoints { get; private set; }
    public int healtPoints { get; private set; } 
    public int pointsRecord { get; private set; }
    public int multiplicator { get; private set; }
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

        levelMapping.EnemySpawner(timer);  // Instancia de enemigos
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
            levelMapping.Spawning(false);
        }
    }

    private void Lose()
    {
        if (healtPoints <= 0) //si la vida es menor o igual a 0, pierde y se invoca al evento Onlose
        {
            OnLose?.Invoke();
            levelEnded = true;
            levelMapping.Spawning(false);
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
