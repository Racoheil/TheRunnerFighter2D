using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsSaveService : ISaveService
{
    private string PlayerBalanceKey = "PlayerBalance"; //////////
                                                       //////////
    private string BestScoreKey = "PlayerBalance";     //////////   Ключи для сохраненных данных
                                                       //////////
    private string Booster1Key = "Booster1Key";        //////////
                                                       //////////
    private string Booster2Key = "Booster2Key";        //////////

    private int _boostersCount = 2;

    private int _defaultValue = 0;
   public void SavePlayerBalance(int value)            // Сохранение баланса
    {
        PlayerPrefs.SetInt(PlayerBalanceKey, value);
    }
    public int GetPlayerBalance()                     // Получить баланс
    {
        return PlayerPrefs.GetInt(PlayerBalanceKey, 0);
    }

    public void SaveBestScore(int value)             // Сохранить рекорд
    {
        PlayerPrefs.SetInt(BestScoreKey, value);
    }
    public int GetBestScore()                        // Получить рекорд
    {
        return PlayerPrefs.GetInt(BestScoreKey);
    }
    public void SaveBoosterCount(int numberOfBooster, int count)   // Сохраняем количество определенного бустера
    {                                                              // Указываем номер бустера и количество
        switch (numberOfBooster)
        {
            case 1:

                PlayerPrefs.SetInt(Booster1Key, count);
                break;

            case 2:

                PlayerPrefs.SetInt(Booster2Key, count);
                break;
        }
    }

    public int GetBoosterCount(int numberOfBooster)
    {
        switch (numberOfBooster)
        {
            case 1:

                return PlayerPrefs.GetInt(Booster1Key, _defaultValue);
                break;

            case 2:

                return PlayerPrefs.GetInt(Booster2Key, _defaultValue);
                break;

            default: return default;
        }
    }
    public void AddBooster(int numberOfBooster)
    {
        switch (numberOfBooster)
        {
            case 1:

                int newCountBooster1 = PlayerPrefs.GetInt(Booster1Key, _defaultValue) + 1;
                SaveBoosterCount(numberOfBooster, newCountBooster1);
                break;

            case 2:

                int newCountBooster2 = PlayerPrefs.GetInt(Booster2Key, _defaultValue) + 1;
                SaveBoosterCount(numberOfBooster, newCountBooster2);
                break;
        }
    }
    public void RemoveBooster(int numberOfBooster)
    {
        switch (numberOfBooster)
        {
            case 1:

                int newCountBooster1 = PlayerPrefs.GetInt(Booster1Key, _defaultValue) - 1;
                SaveBoosterCount(numberOfBooster, newCountBooster1);
                break;

            case 2:

                int newCountBooster2 = PlayerPrefs.GetInt(Booster2Key, _defaultValue) - 1;
                SaveBoosterCount(numberOfBooster, newCountBooster2);
                break;
        }
    }
}
