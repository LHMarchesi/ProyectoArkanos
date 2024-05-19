using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Analytics;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Circles;
    private bool canSpawn;

    void Start()
    {
       
        canSpawn = true;
    }

    public void StopSpawning(bool canSpawn) // Detiene spawn de enemigos
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

    public void EnemySpawner(float timer) {
        if (canSpawn)
        {
            float errorMargin = .1f; // Define un margen de error aceptable
            float timeToResume = .3f;


            // Compara la diferencia entre el temporizador y los valores deseados con el margen de error
            if (Mathf.Abs(timer - 11.21862f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }
            if (Mathf.Abs(timer - 13.46748f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }
            if (Mathf.Abs(timer - 16.35484f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false;
                Invoke("ResumeSpawning", timeToResume);
            }
            if (Mathf.Abs(timer - 18.67138f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            } if (Mathf.Abs(timer - 20.99046f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            } if (Mathf.Abs(timer - 23.27908f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            } if (Mathf.Abs(timer - 27.8566f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            } if (Mathf.Abs(timer - 29.67364f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            } if (Mathf.Abs(timer - 30.79164f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            } if (Mathf.Abs(timer - 31.9279f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 33.0863f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 34.27032f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 35.43092f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 36.56873f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 37.72823f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 38.88709f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 40.03931f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 41.17375f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 42.31313f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 43.44522f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 44.5989f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 45.73062f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 46.93214f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 48.08496f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 49.2006f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 50.40139f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 51.57785f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 52.77698f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 54.47568f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 55.60763f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 56.76097f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 57.91984f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 59.02995f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 60.14233f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 61.36771f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 62.52703f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 63.61687f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 65.38578f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 66.54424f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 67.67699f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 68.88331f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 70.04167f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 71.19888f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 72.35323f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 73.49273f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 74.62603f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 75.78403f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 76.91685f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 78.09384f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 79.25592f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 80.49273f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 81.52637f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 82.68584f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }if (Mathf.Abs(timer - 83.88785f) <= errorMargin)
            {
                AddEnemy();
                canSpawn = false; 
                Invoke("ResumeSpawning", timeToResume);
            }
        }
    }

    void ResumeSpawning()
    {
        canSpawn = true; // Reanuda la generación de enemigos
    }
}
