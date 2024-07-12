using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    private ISaveService _saveService;

    private int _booster1Price = 100;

    private int _booster2Price = 100;

    [SerializeField] private TMP_Text _booster1PriceText;

    [SerializeField] private TMP_Text _booster2PriceText;

    [SerializeField] private TMP_Text _booster1CountText;

    [SerializeField] private TMP_Text _booster2CountText;

    private void Start()
    {
        _saveService = new PrefsSaveService();
        SetBoostersPrices();
        SetAllBoostersCount();
    }
    private void SetBoostersPrices()
    {
        _booster1PriceText.text = "$" + _booster1Price.ToString();

        _booster2PriceText.text = "$" + _booster2Price.ToString();
    }
    private void SetAllBoostersCount()
    {
        int booster1Count = _saveService.GetBoosterCount(1);
        int booster2Count = _saveService.GetBoosterCount(2);
        _booster1CountText.text = booster1Count.ToString();
        _booster2CountText.text = booster2Count.ToString();
    }
    public void BuyBooster(int numberOfbooster)
    {
        switch (numberOfbooster)
        {
            case 1:

                if (PlayerBalance.instance.GetPlayerBalance() >= _booster1Price)
                {
                    _saveService.AddBooster(numberOfbooster);
                    PlayerBalance.instance.ReduceBalance(_booster1Price);

                    SetAllBoostersCount();
                }
                else print("No money");

                break;

            case 2:

                if (PlayerBalance.instance.GetPlayerBalance() >= _booster2Price)
                {
                    _saveService.AddBooster(numberOfbooster);
                    PlayerBalance.instance.ReduceBalance(_booster2Price);

                    SetAllBoostersCount();
                }
                else print("No money");

                break;
        }
    }
}
