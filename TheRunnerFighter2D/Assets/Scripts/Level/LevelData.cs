using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    private int _currentLevel;

    public static LevelData instance;

    private void OnEnable()
    {
        EventService.OnPlayerChangeLevel += IncreaseCurrentLevel;
    }
    private void OnDisable()
    {
        EventService.OnPlayerChangeLevel -= IncreaseCurrentLevel;
    }
    private void Awake()
    {
        instance = this;
        _currentLevel = 1;
    }
    public int GetCurrentLevel()
    {
        return _currentLevel;
    }

    public void IncreaseCurrentLevel()
    {
        _currentLevel++;
    }
}
