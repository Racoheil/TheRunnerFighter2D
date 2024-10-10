using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameDataHolder
{
    private static bool _isMusicEnable = true;
    private static bool _isSoundEnable = true;

    public static void SetMusicState(bool value)
    {
        _isMusicEnable = value;
    }
    public static bool GetMusicState()
    {
        return _isMusicEnable;
    }
    public static void SetSoundState(bool value)
    {
        _isSoundEnable = value;
    }
    public static bool GetSoundState()
    {
        return _isSoundEnable;
    }
}
