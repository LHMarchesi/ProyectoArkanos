using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject spawnPos;
    [SerializeField] private GameObject player;
    [SerializeField] private string nextLevel;
    [SerializeField] private string currentLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ScenesLoader.instance.LoadScene(nextLevel);
            ScenesLoader.instance.LoadSceneAsync(currentLevel);
            //player.transform.position = spawnPos.transform.position;
        }
    }
}
