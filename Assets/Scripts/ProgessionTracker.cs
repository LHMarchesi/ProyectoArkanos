using System;
using System.Collections;
using System.Collections.Generic;
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

    public void SaveLevelIndex(int levelIndex)
    {
        PlayerPrefs.SetInt("LevelIndex", levelIndex);
        PlayerPrefs.Save();
    }

    public void RestartIndex()
    {
        levelIndex = 0;
        PlayerPrefs.SetInt("LevelIndex", levelIndex);
        PlayerPrefs.Save();
    }

    public void ContinueFromIndex()
    {
        PlayerPrefs.SetInt("LevelIndex", levelIndex);
        PlayerPrefs.Save();
    }
}
