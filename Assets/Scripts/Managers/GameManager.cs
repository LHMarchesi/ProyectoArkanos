using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } 
    

    private void Awake()
    {
       
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void IsEnemy(GameObject gameObject)  // Interaccion con enemigos
    {
        if (gameObject.CompareTag("Enemy"))
        {
            ScenesLoader.instance.LoadNextScene();
        }
    }
}
