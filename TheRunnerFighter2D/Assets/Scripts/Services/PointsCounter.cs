using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class PointsCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointsCounterText;
    [SerializeField] private TMP_Text _addingPointsText;

    private int _pointsCount;

    private float _countDelay = 1.5f;

    private bool _isCount;

    private Color _colorLevel1 = Color.white;
    private Color _colorLevel2 = Color.green;
    private Color _colorLevel3 = Color.red;

    private Color[] _colors;

    private bool _isPaused;

    private void OnEnable()
    {
        EventService.OnPlayerChangeLevel += OnChangeLevel;
        EventService.OnPlayerLose += OnPlayerLose;
        EventService.OnPauseGame += StopCount;
        EventService.OnResumeGame += ContinueCount;
        EventService.OnKillEnemy += AddCounts;
    }
    private void OnDisable()
    {
        EventService.OnPlayerChangeLevel -= OnChangeLevel;
        EventService.OnPlayerLose -= OnPlayerLose;
        EventService.OnPauseGame -= StopCount;
        EventService.OnResumeGame -= ContinueCount;
        EventService.OnKillEnemy -= AddCounts;

    }
    private void Awake()
    {
        _isPaused = false;
        _isCount = true;
        _pointsCount = 0;
        _pointsCounterText.text = _pointsCount.ToString();

        _colors = new Color[] { _colorLevel1, _colorLevel2, _colorLevel3 };
    }
    private void Start()
    {
        _addingPointsText.gameObject.SetActive(false);

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
       // _isCount = false;
        _isPaused = true;
    }
    private void ContinueCount()
    {
       // _isCount = true;
        _isPaused = false;
       // StartCoroutine(PointsCountCoroutine());
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

    private void AddCounts(int value)
    {
        StartCoroutine(AddPointsRoutine(value));
    }
    private IEnumerator PointsCountCoroutine()
    {
        while (_isCount)
        {
            if (!_isPaused && PlayerMovement.instance.GetRigidBodyVectorX() > 0.5f)
            {
                _pointsCount++;
                //print(_pointsCount);
                _pointsCounterText.text = _pointsCount.ToString();
            }
            //float delay = PlayerMovement.instance.GetRigidBodyVectorX() + 0.1f;
            //print("delay = " + delay);
            yield return new WaitForSecondsRealtime(_countDelay);
        }
    }
    private IEnumerator AddPointsRoutine(int addingValue)
    {
        _addingPointsText.gameObject.SetActive(true);
        _addingPointsText.text = "+" + addingValue.ToString();

        Color originalColor = _addingPointsText.color;
        Color newColor = _addingPointsText.color;

      
        float fadeDuration = 1f;
        int i = 0;
        while (newColor.a > 0)
        {
            i++;
            print("i = " + i);
            newColor.a -= Time.deltaTime / fadeDuration;
            print("Delta time = " + Time.deltaTime);
            _addingPointsText.color = newColor;
            yield return null;
        }

        _addingPointsText.color = originalColor;
        _addingPointsText.gameObject.SetActive(false);

        _pointsCount += addingValue;
        _pointsCounterText.text = _pointsCount.ToString();
   
    }
}
