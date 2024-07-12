using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _balanceText;

    private int _playerBalance;

    private ISaveService _prefsSaveService;

    public static PlayerBalance instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _prefsSaveService = new PrefsSaveService();
        LoadPlayerBalance();
    }

    public int GetPlayerBalance()
    {
        return _playerBalance;
    }

    public void LoadPlayerBalance()
    {
        int balance = _prefsSaveService.GetPlayerBalance();
        _balanceText.text = balance.ToString();
        _playerBalance = balance;
    }

    public void ReduceBalance(int value)
    {
        _playerBalance -= value;
        _prefsSaveService.SavePlayerBalance(_playerBalance);
        _balanceText.text = _playerBalance.ToString();
    }
}
