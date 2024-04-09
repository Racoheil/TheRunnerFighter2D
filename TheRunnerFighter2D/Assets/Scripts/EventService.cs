using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventService
{
    public static event Action OnTakeDamage;
    public static void CallOnTakeDamage()
        =>OnTakeDamage?.Invoke();
}
