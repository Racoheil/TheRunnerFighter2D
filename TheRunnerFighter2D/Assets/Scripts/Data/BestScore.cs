using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BestScore : MonoBehaviour
{
    [SerializeField] TMP_Text _bestScoreText;

    [SerializeField] PointsCounter _pointsCounter;

    [SerializeField] GameObject _bestScoreLabel;

    private string _bestScoreKey = "playerBestScore";

    private int _bestScore;

    private void OnEnable()
    {
        EventService.OnPlayerLose += CompareScore;
    }
    private void OnDisable()
    {
        EventService.OnPlayerLose -= CompareScore;
    }

    private void Start()
    {
        LoadScore();
        _bestScoreLabel.SetActive(false);
    }
    private void LoadScore()
    {
        if (PlayerPrefs.HasKey(_bestScoreKey))
        {
            _bestScore = PlayerPrefs.GetInt(_bestScoreKey, 0);
        }
        _bestScoreText.text = _bestScore.ToString();
    }

    private void SetNewBestScore(int value)
    {
        _bestScore = value;
        PlayerPrefs.SetInt(_bestScoreKey, value);
        _bestScoreText.text = value.ToString();
    }
    private void CompareScore()
    {
        if(_pointsCounter.GetPointsCount() > _bestScore)
        {
            SetNewBestScore(_pointsCounter.GetPointsCount());
            _bestScoreLabel.SetActive(true);
        }
    }
}
