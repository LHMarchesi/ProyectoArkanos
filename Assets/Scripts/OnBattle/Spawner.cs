using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Analytics;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Circles;
    [SerializeField] private float spawnTime;
    private float nextSpawn;       
    [SerializeField] private bool canSpawn;       


    private Vector2 spawnPos;
    private Coroutine spawnCoroutine;

    void Start()
    {
        canSpawn = true;
        nextSpawn = 0;


    }

    private void Update()
    {
        nextSpawn += Time.deltaTime;

        if (nextSpawn >= spawnTime && canSpawn) 
        {
            nextSpawn = 0;
            AddEnemy();

        }
    }

    public void StopSpawning(bool canSpawn) // Detiene spawn de enemigos
    {
        this.canSpawn = canSpawn;
        
    }public void ChangeSpawnTime(float spawnTime) // Cambia spawn de enemigos
    {
        this.spawnTime = spawnTime;
        
    }
    
    private void AddEnemy() // Instancia los enemigos
    {
        int randomValue = Random.Range(0, Circles.Length);

        float randomX = Random.Range(-8, 3);
        float randomY = Random.Range(-4, 4);

        spawnPos = new Vector2(randomX, randomY);

        Instantiate(Circles[randomValue], spawnPos, Quaternion.identity);
    }

}
