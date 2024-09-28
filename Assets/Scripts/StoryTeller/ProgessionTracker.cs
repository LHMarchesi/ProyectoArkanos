using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgessionTracker : MonoBehaviour
{
    static ProgessionTracker instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] public int levelIndex;// LevelIndex para rastrear el nivel

    public void IncreaseLevelIndex()
    {
        levelIndex++;
        SaveLevelIndex(levelIndex);
    }

    public int LoadLevelIndex()
    {
        SaveLevelIndex(levelIndex);
        return levelIndex;
    }

    public void SaveLevelIndex(int index)
    {
        PlayerPrefs.SetInt("LevelIndex", index);
        PlayerPrefs.Save();
    }

    public void RestartIndex()
    {
        levelIndex = 0;
        SaveLevelIndex(levelIndex);
    }

    public void ContinueFromIndex()
    {
        PlayerPrefs.SetInt("LevelIndex", LoadLevelIndex());
        PlayerPrefs.Save();
    }
}
