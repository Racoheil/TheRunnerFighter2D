using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioSource _musicSource;

    [SerializeField] AudioClip _mainMenuMusic, _gameMusic;

    private void OnEnable()
    {
        EventService.OnStartGame += PlayGameMusic;
        EventService.OnPauseGame += PauseMusic;
        EventService.OnClosePausePanel += UnpauseMusic;
        EventService.OnPlayerLose += StopMusic;
        EventService.OnPlayerChangeLevel += SpeedUpMusic;
    }
    private void OnDisable()
    {
        EventService.OnStartGame -= PlayGameMusic;
        EventService.OnPauseGame -= PauseMusic;
        EventService.OnClosePausePanel -= UnpauseMusic;
        EventService.OnPlayerLose -= StopMusic;
        EventService.OnPlayerChangeLevel -= SpeedUpMusic;
    }

    private void Start()
    {
        PlayMainMenuMusic();
    }
    private void StopMusic()
    {
        _musicSource.Stop();
    }

    private void PlayMainMenuMusic()
    {
        _musicSource.Stop();
        PlayMelody(_mainMenuMusic, 0.8f);
        print("Menu Music volume = " + _musicSource.volume);
    }
    private void PlayGameMusic()
    {
        _musicSource.Stop();
        PlayMelody(_gameMusic, 1f);
        print("Game Music volume = " + _musicSource.volume);
    }
    public void PlayMelody(AudioClip audio, float volume)
    {
        _musicSource.PlayOneShot(audio, volume);
    }

    public void PauseMusic()
    {
        _musicSource.Pause();
    }
    public void UnpauseMusic()
    {
        _musicSource.UnPause();
    }
    public void SpeedUpMusic()
    {
        _musicSource.pitch += 0.06f;
        print("music speed = " + _musicSource.pitch);
    }
    //public void ChangeMusicSpeed(float value)
    //{
    //    _musicSource.pitch = value;
    //}
}
