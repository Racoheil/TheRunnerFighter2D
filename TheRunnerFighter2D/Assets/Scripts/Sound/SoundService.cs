using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundService : MonoBehaviour
{
    [SerializeField] private AudioClip ButtonTap, PlayerDeath;

    [SerializeField] private AudioSource _audioSource;

    public void PlaySound(AudioClip audio)
    {
        _audioSource.PlayOneShot(audio);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayButtonTapSound();
        }
    }
    public void PlayButtonTapSound()
    {
        PlaySound(ButtonTap);
    }
}
