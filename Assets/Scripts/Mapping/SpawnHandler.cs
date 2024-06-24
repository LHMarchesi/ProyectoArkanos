using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    [SerializeField] private LevelMap levelMap;
    [SerializeField] public int LevelIndex;
   
    [SerializeField] private GameObject[] Circles;
    [SerializeField] private float[] spawnTimes; // Array de tiempos de spawn

    private bool canSpawn = true;
    private float errorMargin = 0.1f;
    private float timeToResume = 0.3f;
    float minDistanceBetweenCircles = 1.5f;
    float deSpawnTime;


    public void SetLevel()
    {
        int levelIndex = LevelIndex;
        switch (levelIndex)
        {
            case 1:
                spawnTimes = levelMap.MapLevel1;
                break;
            case 2:
                spawnTimes = levelMap.MapLevel2;
                break;
            case 3:
                // spawnTimes = levelMap.MapLevel3;
                break;
            default:
                Debug.LogError("Invalid level index!");
                break;
        }
    }


    public void Spawning(bool canSpawn) // Detiene spawn de Circulos
    {
        this.canSpawn = canSpawn;
    }
   
    public void CircleSpawnhandleer(float timer) // Mapeo
    {
       
        if (canSpawn)
        {
            foreach (float spawnTime in spawnTimes)
            {
                if (Mathf.Abs(timer - (spawnTime - deSpawnTime)) <= errorMargin)
                {
                    AddCircle();
                    canSpawn = false;
                    Invoke("ResumeSpawning", timeToResume);
                    break;
                }
            }
        }
    }

    private void AddCircle() // Añade los Circulos en una poscion valida
    {
        int attempts = 0;
        int randomValue = Random.Range(0, Circles.Length);
        bool validPosition = false;
        Vector2 spawnPos;

        do
        {
            float randomX = Random.Range(-8, 3);
            float randomY = Random.Range(-4, 4);
            spawnPos = new Vector2(randomX, randomY);  // Toma posicion random
            validPosition = true;

            foreach (GameObject circle in GameObject.FindGameObjectsWithTag("Circle")) // Por cada circulo en escena
            {
                if (Vector2.Distance(spawnPos, circle.transform.position) < minDistanceBetweenCircles) // Si no esta encima de otro circulo 
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
            GetDespawnTime(newCircle);
            newCircle.tag = "Circle";
        }
    }

    private void GetDespawnTime(GameObject newCircle)
    {
        Circle circleScript = newCircle.GetComponent<Circle>();
        deSpawnTime = circleScript.DeSpawnTime;
    }

    void ResumeSpawning() 
    {
        canSpawn = true;
    }
}
