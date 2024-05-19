using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsHandler : MonoBehaviour
{
    private bool _isEscPressed;

    private void Awake()
    {
        _isEscPressed = false;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            EventService.CallOnArmorBonusActivate();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            EventService.CallOnFlightBonusActivate();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isEscPressed != true)
            {
                EventService.CallOnPauseGame();
                _isEscPressed = true;
            }
            else
            {
                EventService.CallOnClosePausePanel();
                _isEscPressed = false;
                return;
            }
        }
    }
}
