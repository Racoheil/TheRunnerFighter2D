using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseWinService : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;

    private void OnEnable()
    {
        EventService.OnPlayerLose += DoOnLose;
    }
    private void Awake()
    {
        _losePanel.SetActive(false);
    }

    private void DoOnLose()
    {
        _losePanel.SetActive(true); 
    }
}
