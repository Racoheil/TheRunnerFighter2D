using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _boosterShopButton;
    [SerializeField] private GameObject _boosterShopPanel;

    private void Start()
    {
        _startGameButton.onClick.AddListener(StartGame);
        _boosterShopButton.onClick.AddListener(BoosterShop);
    }
    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    private void BoosterShop()
    {
        _boosterShopPanel.SetActive(true);
    }
}
