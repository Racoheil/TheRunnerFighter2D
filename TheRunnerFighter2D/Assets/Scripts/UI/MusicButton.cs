using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    [SerializeField] Sprite _musicOnSprite, _musicOffSprite;

    private Button _musicButton;

    private bool _isMusicEnable;

    private void Awake()
    {
        _isMusicEnable = true;
        _musicButton = GetComponent<Button>();
        _musicButton.onClick.AddListener(PressMusicButton);

    }
    private void Start()
    {
       
    }
    private void PressMusicButton()
    {
        if (_isMusicEnable == true)
        {
            DisableMusic();
            _isMusicEnable = false;
        }
        else if (_isMusicEnable == false)
        {
            EnableMusic();
            _isMusicEnable = true;
        }
    }
    private void EnableMusic()
    {
        EventService.CallOnMusicEnable();
        _musicButton.image.sprite = _musicOnSprite;
        print("enable");
    }

    private void DisableMusic()
    {
        EventService.CallOnMusicDisable();
        _musicButton.image.sprite = _musicOffSprite;
        print("disable");

    }
}
