using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsPanel : MonoBehaviour
{
    [SerializeField] private List<Image> _hearts;

    [SerializeField] private Image _heart;

    [SerializeField] private GameObject _heartPrefab;

    private int _heartsCount = 3;

    void Awake()
    {
       // FillHeartsPanel(3);
    }

    public void ReduceHearts()
    {
        _heartsCount--;
    }

    public void IncreaseHearts()
    {
        _heartsCount++;
    }

    //public void ResetHearts()
    //{
    //    foreach (var heart in _hearts)
    //    {
    //        _heartsCount = _maxHearts;
    //        heart.sprite = fullHeart;
    //    }
    //}

    public void FillHeartsPanel(int value)
    {
        for(int i =0; i < value; i++)
        {
            GameObject heart = Instantiate(_heartPrefab);

            heart.transform.SetParent(this.transform);

        }
    }
}
