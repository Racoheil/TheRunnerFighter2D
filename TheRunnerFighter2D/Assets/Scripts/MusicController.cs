using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioSource _musicSource;

    [SerializeField] AudioClip _mainMenuMusic, _gameMusic;

    private bool _isGameRunning;

    private void OnEnable()
    {
        EventService.OnStartGame += PlayGameMusic;
        //EventService.OnPauseGame += PauseMusic;
        //EventService.OnClosePausePanel += UnpauseMusic;
        EventService.OnPlayerLose += StopMusic;
        EventService.OnPlayerChangeLevel += SpeedUpMusic;
        EventService.OnMusicEnable += EnableMusicSource;
        EventService.OnMusicDisable += DisableMusicSource;
    }
    private void OnDisable()
    {
        EventService.OnStartGame -= PlayGameMusic;
        //EventService.OnPauseGame -= PauseMusic;
        //EventService.OnClosePausePanel -= UnpauseMusic;
        EventService.OnPlayerLose -= StopMusic;
        EventService.OnPlayerChangeLevel -= SpeedUpMusic;
        EventService.OnMusicEnable -= EnableMusicSource;
        EventService.OnMusicDisable -= DisableMusicSource;
    }
    
    private void Awake()
    {
        _isGameRunning = false;
        if (GameDataHolder.GetMusicState())
        {
            PlayMainMenuMusic();
        }
    }
    private void StopMusic()
    {
        _musicSource.Stop();
    }

    private void PlayMainMenuMusic()
    {
        _isGameRunning = false;
        _musicSource.Stop();
        PlayMelody(_mainMenuMusic, 0.8f);
        print("Menu Music volume = " + _musicSource.volume);
    }
    private void PlayGameMusic()
    {
        _isGameRunning = true;
        _musicSource.Stop();
        PlayMelody(_gameMusic, 1f);
        print("Game Music volume = " + _musicSource.volume);
    }
    public void PlayMelody(AudioClip audio, float volume)
    {
        if (GameDataHolder.GetMusicState() == false) return;
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
    public void EnableMusicSource()
    {
        GameDataHolder.SetMusicState(true);
        if (_isGameRunning == true)
        {
            PlayGameMusic();
        }
        else if(_isGameRunning == false)
        {
            PlayMainMenuMusic();
        }
    }
    public void DisableMusicSource()
    {
        _musicSource.Pause();
        GameDataHolder.SetMusicState(false);
    }
}
