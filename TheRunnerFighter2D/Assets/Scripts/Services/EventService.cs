using System;

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

    public static event Action<int> OnBoosterButtonPressed;
    public static void CallOnBoosterButtonPressed(int boosterNumber)
        => OnBoosterButtonPressed?.Invoke(boosterNumber);

    public static event Action OnArmorBoosterActivate;
    public static void CallOnArmorBoosterActivate()
        => OnArmorBoosterActivate?.Invoke();

    public static event Action OnFlightBoosterActivate;
    public static void CallOnFlightBoosterActivate()
        => OnFlightBoosterActivate?.Invoke();

    public static event Action OnPauseGame;
    public static void CallOnPauseGame()
        => OnPauseGame?.Invoke();

    public static event Action OnClosePausePanel;
    public static void CallOnClosePausePanel()
        => OnClosePausePanel?.Invoke();
    

    public static event Action OnResumeGame;
    public static void CallOnResumeGame()
        => OnResumeGame?.Invoke();

    public static event Action OnFlightBoosterDeactivate;
    public static void CallOnFlightBoosterDeactivate()
        => OnFlightBoosterDeactivate?.Invoke();

    public static event Action OnPlayerReachedBackgroundMiddle;
    public static void CallOnPlayerReachedBackgroundMiddle()
        => OnPlayerReachedBackgroundMiddle?.Invoke();

    public static event Action<int> OnKillEnemy;
    public static void CallOnKillEnemy(int pointsCount)
        => OnKillEnemy?.Invoke(pointsCount);

    public static event Action OnStartGame;
    public static void CallOnStartGame()
        => OnStartGame?.Invoke();
    
    public static event Action OnAttackSound;
    public static void CallOnAttackSound()
        => OnAttackSound?.Invoke();

    public static event Action OnEnemyTakeDamageSound;
    public static void CallOnEnemyTakeDamageSound()
        => OnEnemyTakeDamageSound?.Invoke();

    public static event Action OnEnemyDie;
    public static void CallOnEnemyDie()
        => OnEnemyDie?.Invoke();



}
