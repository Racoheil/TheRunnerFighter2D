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
   public void SavePlayerBalance(int value)            // Сохранение баланса
    {
        PlayerPrefs.SetInt(PlayerBalanceKey, value);
    }
    public int GetPlayerBalance()                     // Получить баланс
    {
        return PlayerPrefs.GetInt(PlayerBalanceKey);
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

    public int GetBoosterCount(int numberOfBooster, int count)
    {
        switch (numberOfBooster)
        {
            case 1:

                return PlayerPrefs.GetInt(Booster1Key);
                break;

            case 2:

                return PlayerPrefs.GetInt(Booster2Key);
                break;

            default: return default;
        }
    }
}
