using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    private ScenesLoader scenesLoader;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        scenesLoader = GameObject.Find("SceneLoadManager").GetComponent<ScenesLoader>();
    }
    public void IsEnemy(GameObject gameObject)
    {
        if (gameObject.CompareTag("Enemy"))
        {
            scenesLoader.LoadNextScene();
        }
    }
}
