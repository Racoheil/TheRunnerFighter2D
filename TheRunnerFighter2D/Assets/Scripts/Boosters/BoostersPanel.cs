using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoostersPanel : MonoBehaviour
{
    private ISaveService _saveService;

    [SerializeField] private TMP_Text _booster1CountText;

    [SerializeField] private TMP_Text _booster2CountText;

    private int _booster1Count;

    private int _booster2Count;

    public static BoostersPanel _instance;

    private void OnEnable()
    {
        //EventService.OnStartGame += ActivatePanel;

        SetAllBoostersCount();  
    }
    private void OnDisable()
    {
       // EventService.OnStartGame -= ActivatePanel;
    }
    private void Awake()
    {
       // this.enabled = false;
        _saveService = new PrefsSaveService();
    }
    private void Start()
    {
        SetAllBoostersCount();
        _instance = this;
    }
    private void ActivatePanel()
    {
        this.enabled = true;
        //this.gameObject.SetActive()
    }
    private void SetAllBoostersCount()
    {
        print("setting Count");
        _booster1Count = _saveService.GetBoosterCount(1);
        _booster2Count = _saveService.GetBoosterCount(2);
        _booster1CountText.text = _booster1Count.ToString();
        _booster2CountText.text = _booster2Count.ToString();
    }

    public void UseBooster(int numberOfbooster)
    {
        switch (numberOfbooster)
        {
            case 1:

                if (_booster1Count > 0)
                {
                    _saveService.RemoveBooster(numberOfbooster);

                    SetAllBoostersCount();
                }
                else print("No boosters!");

                break;

            case 2:

                if (_booster2Count > 0)
                {
                    _saveService.RemoveBooster(numberOfbooster);

                    SetAllBoostersCount();
                }
                else print("No boosters!");

                break;
        }
    }

}
