using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMapping : MonoBehaviour
{
    [SerializeField] private GameObject[] Circles;
    [SerializeField] private float[] spawnTimes; // Array de tiempos de spawn
    private float errorMargin = 0.1f;
    private float timeToResume = 0.3f; 

    private bool canSpawn;

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

        float randomX = Random.Range(-8, 3);
        float randomY = Random.Range(-4, 4);

        Vector2 spawnPos = new Vector2(randomX, randomY);

        Instantiate(Circles[randomValue], spawnPos, Quaternion.identity);
    }

    public void EnemySpawner(float timer)  // Spawneo
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

    void ResumeSpawning()
    {
        canSpawn = true; // Reanuda la generación de enemigos
    }
}
