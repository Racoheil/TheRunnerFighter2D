using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseWinService : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;

    private float _loseDelay = 2f;
    private void OnEnable()
    {
        EventService.OnPlayerLose += DoOnLose;
    }
    private void OnDisable()
    {
        EventService.OnPlayerLose -= DoOnLose;
    }
    private void Awake()
    {
        _losePanel.SetActive(false);
    }

    private void DoOnLose()
    {
        StartCoroutine(LoseRoutine());
    }
    
    private IEnumerator LoseRoutine()
    {
        yield return new WaitForSecondsRealtime(_loseDelay);
        _losePanel.SetActive(true);
    }
}
