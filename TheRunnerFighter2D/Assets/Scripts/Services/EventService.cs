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
}
