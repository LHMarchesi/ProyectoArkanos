using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class GameManager : MonoBehaviour
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
    public TextMeshProUGUI pointsTextWLoseMenu;

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
        timer += Time.deltaTime;

        Win(winingPoints);
        Lose(losingPoints);

        Difficulty();

        progessBar.UpdateProgess(totalpoints,winingPoints);
    }

    public void PointsManager(int points)  // maneja el puntaje y lo muestra en texto
    {
        totalpoints += points;
        pointsText.text = totalpoints.ToString();
    }

    private void Win(int points) {

        if (totalpoints > points) //si los puntos totales son menor que los puntos, gana y se activa el canvas 
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
            pointsTextWLoseMenu.text = "Puntos totales : " + totalpoints.ToString();
            spawner.StopSpawning(false);
            losingCanvas.SetActive(true); 

        }


    }

    private void Difficulty()
    {
       
            spawner.ChangeSpawnTime(.7f);

        
        
        
        
    }

   

}
