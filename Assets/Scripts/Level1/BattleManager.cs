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
    [SerializeField] private UIManager UIManager;
    [SerializeField] private float songTime;
    [SerializeField] private bool levelEnded = false;

    public static event Action OnLose;
    public static event Action OnWin;

    private float timer = 0;
    public static int totalpoints { get; private set; } = 0;
    public int healtPoints { get; private set; } = 5;
    public int pointsRecord { get; private set; }
    public int multiplicator { get; private set; } = 1;
    private int maxmMultiplicator = 4;

    void Start()
    {
        Time.timeScale = 1;

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

        spawner.EnemySpawner(timer);  // Instancia de enemigos
    }

    public void PointsManager(int points)  // maneja el puntaje y lo muestra en texto
    {
        totalpoints += points;

    }

    private void Win()
    {
        if (timer > songTime) //Cuando el timer, supera el tiempo de la cancion, se invoca el evento OnWin
        {
            levelEnded = true;
            OnWin?.Invoke();
            spawner.Spawning(false);
        }
    }

    private void Lose()
    {
        if (healtPoints <= 0) //si la vida es menor o igual a 0, pierde y se invoca al evento Onlose
        {
            
            levelEnded = true;
            OnLose?.Invoke();
            spawner.Spawning(false);
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
