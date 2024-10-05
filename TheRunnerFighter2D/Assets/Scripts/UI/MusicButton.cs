using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    [SerializeField] SpriteRenderer _musicOnSprite, musicOffSprite;

    private Button _musicButton;

    private bool _isMusicEnable;

    private void Awake()
    {
        _musicButton = GetComponent<Button>();
        _isMusicEnable = true;
    }

    private void EnableMusic()
    {

    }
}
