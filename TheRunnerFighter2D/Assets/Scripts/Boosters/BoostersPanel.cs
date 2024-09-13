using TMPro;
using UnityEngine;

public class BoostersPanel : MonoBehaviour
{
    private ISaveService _saveService;

    [SerializeField] private TMP_Text _booster1CountText;

    [SerializeField] private TMP_Text _booster2CountText;

    private int _booster1Count;

    private int _booster2Count;

    //public static BoostersPanel _instance;

    private void OnEnable()
    {
        SetAllBoostersCount();

        EventService.OnBoosterButtonPressed += UseBooster;
    }
    private void OnDisable()
    {
        EventService.OnBoosterButtonPressed -= UseBooster;
    }
    private void Awake()
    {
        _saveService = new PrefsSaveService();
    }
    private void Start()
    {
        SetAllBoostersCount();
    }
   
    private void SetAllBoostersCount()
    {
       // print("setting Count");
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

                if (_booster1Count > 0 && ArmorBooster.instance.GetActivity() == false)
                {
                    EventService.CallOnArmorBoosterActivate();

                    _saveService.RemoveBooster(numberOfbooster);

                    SetAllBoostersCount();

                    break;
                    
                }
                else
                {
                    print("No 1 boosters!");

                    break;
                }
           
            case 2:

                if (_booster2Count > 0 && FlightBooster.instance.GetActivity() == false)
                {
                    EventService.CallOnFlightBoosterActivate();

                    _saveService.RemoveBooster(numberOfbooster);

                    SetAllBoostersCount();
                    break; 
                }
                else
                {
                    print("No 2 boosters!");

                    break;
                }
        }
    }

}
