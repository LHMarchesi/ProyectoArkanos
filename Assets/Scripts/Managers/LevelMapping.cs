using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMapping : MonoBehaviour
{
    [SerializeField] private GameObject[] Circles;
    [SerializeField] private float[] spawnTimes; // Array de tiempos de spawn

    private bool canSpawn;
    private float errorMargin = 0.1f;
    private float timeToResume = 0.3f; 
    private float minDistanceBetweenCircles = 1.5f; 


    void Start()
    {
        canSpawn = true;
    }

    public void Spawning(bool canSpawn) // Detiene spawn de enemigos
    {
        this.canSpawn = canSpawn;
    }

    private void AddEnemy() // Instancia los enemigos
    {
        int randomValue = Random.Range(0, Circles.Length);

        Vector2 spawnPos;
        int attempts = 0;
        bool validPosition = false;

        do
        {
            float randomX = Random.Range(-8, 3);
            float randomY = Random.Range(-4, 4);
            spawnPos = new Vector2(randomX, randomY);  // Toma posicion random

            validPosition = true;
            foreach (GameObject circle in GameObject.FindGameObjectsWithTag("Circle")) // Circulos en escena
            {
                if (Vector2.Distance(spawnPos, circle.transform.position) < minDistanceBetweenCircles)
                {
                    validPosition = false;
                    break;
                }
            }

            attempts++;
            if (attempts > 1000) // Evitar bucle infinito
            {
                Debug.LogWarning("Could not find a valid position for a new circle.");
                break;
            }

        } while (!validPosition);

        if (validPosition) // Spawneo en posicion valida
        {
            GameObject newCircle = Instantiate(Circles[randomValue], spawnPos, Quaternion.identity);
            newCircle.tag = "Circle"; 
        }
    }

    public void EnemySpawner(float timer) // Mapeo
    {
        if (canSpawn)
        {
            foreach (float spawnTime in spawnTimes)
            {
                if (Mathf.Abs(timer - (spawnTime - 1.5f )) <= errorMargin)
                {
                    AddEnemy();
                    canSpawn = false;
                    Invoke("ResumeSpawning", timeToResume);
                    break; 
                }
            }
        }
    }

    void ResumeSpawning() // Reanuda la generación de enemigos
    {
        canSpawn = true; 
    }
}
