using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonsMusicSprites : MonoBehaviour
{
    [SerializeField] private Sprite _musicButtonOff;
    [SerializeField] private Button _musicButton;

    private void Start()
    {
        _musicButton.onClick.AddListener(ChangeButtonSprite);
    }

    private void ChangeButtonSprite()
    {
        _musicButton.image.sprite = _musicButtonOff;
    }
}
