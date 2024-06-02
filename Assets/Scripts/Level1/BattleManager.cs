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
    [SerializeField] private float songTime;

    public static event Action OnLose;
    public static event Action OnWin;

    private float timer;
    public static int totalpoints { get; private set; }
    public int healtPoints { get; private set; }

    public TextMeshProUGUI pointsText;

    void Start()
    {
        Time.timeScale = 1;
        healtPoints = 5;

        timer = 0;
        totalpoints = 0;

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
        if (timer > songTime) //Cuando el timer, supera el tiempo de la cancion, se invoca el evento OnWin
        {
            OnWin?.Invoke();
            spawner.Spawning(false);
        }
    }

    private void Lose()
    {
        if (healtPoints <= 0) //si la vida es menor o igual a 0, pierde y se invoca al evento Onlose
        {
            OnLose?.Invoke();
            spawner.Spawning(false);
        }
    }

    public void LostHp()
    {
        healtPoints -= 1;
        healthSistem.HpLost(healtPoints);
    }
}
