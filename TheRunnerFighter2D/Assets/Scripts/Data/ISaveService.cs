using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveService
{
    public void SavePlayerBalance(int value);
    public int GetPlayerBalance();


    public void SaveBestScore(int value);
    public int GetBestScore();


    public void SaveBoosterCount(int numberOfBooster, int count);
    public int GetBoosterCount(int numberOfBooster);

    public void AddBooster(int numberOfBooster);



}
