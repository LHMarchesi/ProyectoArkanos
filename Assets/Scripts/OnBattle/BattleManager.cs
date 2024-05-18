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
    
    [SerializeField] private GameObject winingCanvas;
    [SerializeField] private GameObject losingCanvas;

    [SerializeField]private int winingPoints;
    [SerializeField]private int losingPoints;
    [SerializeField] private float songTime;
    private int totalpoints;
    private float timer;

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI pointsTextWinMenu;
    public TextMeshProUGUI pointsTextLoseMenu;

    void Start()
    {
        Time.timeScale = 1;

        timer = 0;
        totalpoints = 0;

        winingCanvas.SetActive(false);
       losingCanvas.SetActive(false);

       PointsManager(totalpoints);
    }

    void Update()
    {
        Lose(losingPoints);
        Win();

        progessBar.UpdateProgess(timer, songTime);  // Barra de progeso

        timer += Time.deltaTime;
        spawner.EnemySpawner(timer);  // Instancia de enemigos
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
