using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuDataLoader : MonoBehaviour
{
    [SerializeField] private TMP_Text _balanceText;

    private ISaveService _prefsSaveService;

    private void Start()
    {
        _prefsSaveService = new PrefsSaveService();
        LoadPlayerBalance();
    }

    public void LoadPlayerBalance()
    {
        _balanceText.text = _prefsSaveService.GetPlayerBalance().ToString();
    }
}
