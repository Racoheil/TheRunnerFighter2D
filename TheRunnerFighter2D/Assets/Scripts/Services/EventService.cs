using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventService
{
    public static event Action OnTakeDamage;
    public static void CallOnTakeDamage()
        =>OnTakeDamage?.Invoke();


    public static event Action OnPlayerFinishingPlatform;
    public static void CallOnPlayerFinishingPlatform()
        =>OnPlayerFinishingPlatform?.Invoke();


    public static event Action OnPlayerChangeLevel;
    public static void CallOnPlayerChangeLevel()
        => OnPlayerChangeLevel?.Invoke();


    public static event Action OnPlayerLose;
    public static void CallOnPlayerLose()
        => OnPlayerLose?.Invoke();


    public static event Action OnArmorBonusActivate;
    public static void CallOnArmorBonusActivate()
        => OnArmorBonusActivate?.Invoke();

    public static event Action OnFlightBonusActivate;
    public static void CallOnFlightBonusActivate()
        => OnFlightBonusActivate?.Invoke();

    public static event Action OnPauseGame;
    public static void CallOnPauseGame()
        => OnPauseGame?.Invoke();

    public static event Action OnClosePausePanel;
    public static void CallOnClosePausePanel()
        => OnClosePausePanel?.Invoke();
    

    public static event Action OnResumeGame;
    public static void CallOnResumeGame()
        => OnResumeGame?.Invoke();

    public static event Action OnFlightBonusDeactivate;
    public static void CallOnFlightBonusDeactivate()
        => OnFlightBonusDeactivate?.Invoke();

    public static event Action OnPlayerReachedBackgroundMiddle;
    public static void CallOnPlayerReachedBackgroundMiddle()
        => OnPlayerReachedBackgroundMiddle?.Invoke();

    public static event Action<int> OnKillEnemy;
    public static void CallOnKillEnemy(int pointsCount)
        => OnKillEnemy?.Invoke(pointsCount);

    public static event Action OnStartGame;
    public static void CallOnStartGame()
        => OnStartGame?.Invoke();
    
}
