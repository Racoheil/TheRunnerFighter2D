using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] Sprite _soundOnSprite, _soundOffSprite;

    private Button _soundButton;

    private void Awake()
    {
        _soundButton = GetComponent<Button>();
        _soundButton.onClick.AddListener(PressSoundButton);

    }
    private void Start()
    {
        SetSoundButtonSprite();
    }
    private void PressSoundButton()
    {
        if (GameDataHolder.GetSoundState() == true)
        {
            DisableSound();
        }
        else if (GameDataHolder.GetSoundState() == false)
        {
            EnableSound();
        }
    }
    private void EnableSound()
    {
        GameDataHolder.SetSoundState(true);
        SetSoundButtonSprite();
        print("GameDataHolder.GetSoundState = "+GameDataHolder.GetSoundState());
    }

    private void DisableSound()
    {
        GameDataHolder.SetSoundState(false);
        SetSoundButtonSprite();
        print("disable");
        print("GameDataHolder.GetSoundState = " + GameDataHolder.GetSoundState());

    }
    private void SetSoundButtonSprite()
    {
        switch (GameDataHolder.GetSoundState())
        {
            case true:
                _soundButton.image.sprite = _soundOnSprite;
                break;

            case false:
                _soundButton.image.sprite = _soundOffSprite;
                break;
        }
    }
}
