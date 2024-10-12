using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameDataHolder
{
    private static bool _isMusicEnable = true;
    private static bool _isSoundEnable = true;
    private static int _languageIndex = 0;
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
    public static void SetLanguageIndex(int value)
    {
        _languageIndex = value;
    }
    public static int GetLanguageIndex()
    {
        return _languageIndex;
    }
}
