using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    private bool _isPaused;
    private bool _isResumed;
    private float _resumeDelay = 0.4f;
    private void OnEnable()
    {
        EventService.OnPauseGame += Pause;
        EventService.OnClosePausePanel += Resume;
    }
    private void OnDisable()
    {
        EventService.OnPauseGame -= Pause;
        EventService.OnClosePausePanel -= Resume;
    }
    private void Awake()
    {
        _isPaused = false;
        _isResumed = false;
        _pausePanel.SetActive(false);
    }
    public void Pause()
    {
        if (!_isResumed && !LevelData.instance.GetIsGameOver())
        {
            _isPaused = true;
            _pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Resume()
    {
        if (_isResumed)
        {
            return;
        }
        else if (!_isResumed)
        {
            _isResumed = true;
            StartCoroutine(ResumeRoutine());
        }
    }

    private IEnumerator ResumeRoutine()
    {
        _isPaused = false;
        _pausePanel.SetActive(false);
        yield return new WaitForSecondsRealtime(_resumeDelay);
        EventService.CallOnResumeGame();
        Time.timeScale = 1;
        _isResumed = false; ;
    }
}
