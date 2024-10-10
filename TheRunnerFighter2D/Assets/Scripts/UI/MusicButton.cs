using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    [SerializeField] Sprite _musicOnSprite, _musicOffSprite;

    private Button _musicButton;

    //private bool _isMusicEnable;

    private void Awake()
    {
        _musicButton = GetComponent<Button>();
        _musicButton.onClick.AddListener(PressMusicButton);

    }
    private void Start()
    {
        SetMusicButtonSprite();
    }
    private void PressMusicButton()
    {
        if (GameDataHolder.GetMusicState() == true)
        {
            DisableMusic();
        }
        else if (GameDataHolder.GetMusicState() == false)
        {
            EnableMusic();
        }
    }
    private void EnableMusic()
    {
        EventService.CallOnMusicEnable();
        SetMusicButtonSprite();
        print("enable");
    }

    private void DisableMusic()
    {
        EventService.CallOnMusicDisable();
        SetMusicButtonSprite();
        print("disable");

    }
    private void SetMusicButtonSprite()
    {
        switch (GameDataHolder.GetMusicState())
        {
            case true:
                _musicButton.image.sprite = _musicOnSprite;
                break;

            case false:
                _musicButton.image.sprite = _musicOffSprite;
                break;
        }
    }
}
