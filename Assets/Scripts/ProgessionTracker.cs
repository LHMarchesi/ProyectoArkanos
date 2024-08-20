using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgessionTracker : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] private int levelIndex;
    public int LevelIndex => levelIndex;// LevelIndex para rastrear el nivel

    public void IncreaseLevelIndex()
    {
        levelIndex++;
        SaveLevelIndex(LevelIndex);
    }

    public int LoadLevelIndex()
    {
        return PlayerPrefs.GetInt("LevelIndex", 0);
    }

    public void SaveLevelIndex(int levelIndex)
    {
        PlayerPrefs.SetInt("LevelIndex", levelIndex);
        PlayerPrefs.Save();
        Console.WriteLine("Nivel guardado " + levelIndex);
    }

    public void UpdateLevelIndex(int newIndex)
    {
        PlayerPrefs.SetInt("LevelIndex", newIndex);
        PlayerPrefs.Save();
        LoadLevelIndex();
    }
}
