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

    private void OnEnable()
    {
        EventService.OnPlayerChangeLevel += OnChangeLevel;
    }
    private void OnDisable()
    {
        EventService.OnPlayerChangeLevel -= OnChangeLevel;
    }
    private void Awake()
    {
        _isCount = true;
        _pointsCount = 0;
        _pointsCounterText.text = _pointsCount.ToString();
    }
    private void Start()
    {
        StartCount();
    }

    private void ChangeCountDelay(float value)
    {
        _countDelay = value;
    }
    private void StartCount()
    {
        StartCoroutine(PointsCountCoroutine());
    }
    private void OnChangeLevel()
    {
        ChangeCountDelay(_countDelay/2.5f);
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
