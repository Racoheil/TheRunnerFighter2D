using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointsCounterText;

    private int _pointsCount;

    private float _countDelay = 1.5f;

    private bool _isCount;

    private Color _colorLevel1 = Color.white;
    private Color _colorLevel2 = Color.green;
    private Color _colorLevel3 = Color.red;

    private Color[] _colors;
    private void OnEnable()
    {
        EventService.OnPlayerChangeLevel += OnChangeLevel;
        EventService.OnPlayerLose += OnPlayerLose;
        EventService.OnPauseGame += StopCount;
        EventService.OnResumeGame += ContinueCount;
    }
    private void OnDisable()
    {
        EventService.OnPlayerChangeLevel -= OnChangeLevel;
        EventService.OnPlayerLose -= OnPlayerLose;
        EventService.OnPauseGame -= StopCount;
        EventService.OnResumeGame -= ContinueCount;

    }
    private void Awake()
    {
        _isCount = true;
        _pointsCount = 0;
        _pointsCounterText.text = _pointsCount.ToString();

        _colors = new Color[] { _colorLevel1, _colorLevel2, _colorLevel3 };
    }
    private void Start()
    {
        StartCount();

        _pointsCounterText.color = _colors[LevelData.instance.GetCurrentLevel()-1];
    }

    private void ChangeCountDelay(float value)
    {
        _countDelay = value;
    }
    private void StartCount()
    {
        _isCount = true;
        StartCoroutine(PointsCountCoroutine());
    }
    private void OnPlayerLose()
    {
        StopCount();
        //HideCounter();
    }
    private void StopCount()
    {
        //StopCoroutine(PointsCountCoroutine());
        _isCount = false;
    }
    private void ContinueCount()
    {
        _isCount = true;
        StartCoroutine(PointsCountCoroutine());
    }

    private void HideCounter()
    {
        _pointsCounterText.enabled = false;
    }
    private void OnChangeLevel()
    {
        ChangeCountDelay(_countDelay/2.5f);
        _pointsCounterText.color = _colors[LevelData.instance.GetCurrentLevel() - 1];
    }
    private IEnumerator PointsCountCoroutine()
    {
        while (_isCount)
        {
            _pointsCount++;
        print(_pointsCount);
        _pointsCounterText.text = _pointsCount.ToString();
        
        yield return new WaitForSecondsRealtime(_countDelay);
        }
    }

}
