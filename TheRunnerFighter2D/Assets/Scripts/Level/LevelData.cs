using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    private int _currentLevel;

    [SerializeField]private bool _isGameOver;

    public static LevelData instance;

    private void OnEnable()
    {
        EventService.OnPlayerChangeLevel += IncreaseCurrentLevel;
        EventService.OnPlayerLose += EnableGameOver;
    }
    private void OnDisable()
    {
        EventService.OnPlayerChangeLevel -= IncreaseCurrentLevel;
        EventService.OnPlayerLose -= EnableGameOver;
    }
    private void Awake()
    {
        instance = this;
        _currentLevel = 1;
        _isGameOver = false;
    }
    public int GetCurrentLevel()
    {
        return _currentLevel;
    }
    public bool GetIsGameOver()
    {
        return _isGameOver;
    }
    public void IncreaseCurrentLevel()
    {
        _currentLevel++;
    }
    public void EnableGameOver()
    {
        _isGameOver = true;
    }
}
