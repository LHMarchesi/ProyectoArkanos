using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class BattleManager : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    [SerializeField] private ScenesLoader scenesLoader;
    [SerializeField] private ProgessBar progessBar;
    

    [SerializeField]private int winingPoints;
    [SerializeField]private int losingPoints;

    [SerializeField] private GameObject winingCanvas;
    [SerializeField] private GameObject losingCanvas;

    private int totalpoints;
    private float timer;

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI pointsTextWinMenu;
    public TextMeshProUGUI pointsTextLoseMenu;
    public TextMeshProUGUI timerTxt;

    void Start()
    {
        timer = 0;

        Time.timeScale = 1;

       winingCanvas.SetActive(false);
       losingCanvas.SetActive(false);

        totalpoints = 0;

       PointsManager(totalpoints);
    }

    void Update()
    {
        Lose(losingPoints);
        Win();

        progessBar.UpdateProgess(totalpoints,winingPoints);

        timer += Time.deltaTime;
        timerTxt.text = timer.ToString();

        spawner.EnemySpawner(timer);
    }

    public void PointsManager(int points)  // maneja el puntaje y lo muestra en texto
    {
        totalpoints += points;
        pointsText.text = totalpoints.ToString();
    }

    private void Win() {

        if (timer > 87) //si los puntos totales son menor que los puntos, gana y se activa el canvas 
        {
            pointsTextWinMenu.text = "Puntos totales : " + totalpoints.ToString();
            Time.timeScale = 0;
            spawner.StopSpawning(false);
            winingCanvas.SetActive(true);

        }

    }
    private void Lose(int points) {


        if (totalpoints < points ) //si los puntos totales son menor que los puntos, pierde y se activa el canvas 
        {
            Time.timeScale = 0;
            pointsTextLoseMenu.text = "Puntos totales : " + totalpoints.ToString();
            spawner.StopSpawning(false);
            losingCanvas.SetActive(true); 

        }


    }

    

   

}
