using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;

    [SerializeField] private GameObject _playerBalance;

    [SerializeField] private GameObject _gamePanel;

    [SerializeField] private GameObject _shopPanel;

    [SerializeField] private GameObject _bestScore;

    private void Start()
    {
        _mainMenuPanel.SetActive(true);
        _playerBalance.SetActive(true);
        _gamePanel.SetActive(false);
        _shopPanel.SetActive(false);
        _bestScore.SetActive(true);
    }
    public void StartGame()
    {
        _mainMenuPanel.SetActive(false);
        _gamePanel.SetActive(true);
        _playerBalance.SetActive(false);
        _bestScore.SetActive(false);

        EventService.CallOnStartGame();
    }

    public void OpenShop()
    {
        _shopPanel.SetActive(true);
        _mainMenuPanel.SetActive(false);
    }
    public void GoToMainMenu()
    {
        _shopPanel.SetActive(false);
        _mainMenuPanel.SetActive(true);
    }
}
