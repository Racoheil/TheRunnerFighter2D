using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;

    [SerializeField] private GameObject _gamePanel;

    private void Start()
    {
        _mainMenuPanel.SetActive(true);
        _gamePanel.SetActive(false);
    }
    public void StartGame()
    {
        _mainMenuPanel.SetActive(false);
        _gamePanel.SetActive(true);

        EventService.CallOnStartGame();
    }
}
