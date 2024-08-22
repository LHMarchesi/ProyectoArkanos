using UnityEngine;

public class ProgessionTracker : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        levelIndex = LoadLevelIndex();
    }

    [SerializeField] private int levelIndex;// LevelIndex para rastrear el nivel

    public void IncreaseLevelIndex()
    {
        levelIndex++;
        SaveLevelIndex(levelIndex);
    }

    public int LoadLevelIndex()
    {
        return PlayerPrefs.GetInt("LevelIndex", 0);
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
