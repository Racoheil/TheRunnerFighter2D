using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    private Button _exitButton;
    private void Awake()
    {
        _exitButton = GetComponent<Button>();
        _exitButton.onClick.AddListener(ExitGame);
    }
    private void ExitGame()
    {
        Application.Quit();
    }
}
