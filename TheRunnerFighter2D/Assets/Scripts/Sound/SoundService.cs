using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundService : MonoBehaviour
{
    [SerializeField] private AudioClip
        ButtonTap,
        AttackSound,
        EnemyDamage,
        EnemyDie,
        GameStart,
        PlayerJump,
        EnemyShot,
        BoosterBuy,
        NotEnoughMoney,
        PlayerDeath;

    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        EventService.OnAttackSound += PlayAttackSound;
        EventService.OnEnemyTakeDamageSound += PlayEnemyDamage;
        EventService.OnStartGame += PlayStartGame;
        EventService.OnEnemyDieSound += PlayEnemyDie;
        EventService.OnPlayerJumpSound += PlayPlayerJump;
        EventService.OnEnemyShotSound += PlayEnemyShot;
        EventService.OnNotEnoughMoney += PlayNotEnoughMoney;
        EventService.OnBoosterBuy += PlayBoosterBuy;
    }
    private void OnDisable()
    {
        EventService.OnAttackSound -= PlayAttackSound;
        EventService.OnEnemyTakeDamageSound -= PlayEnemyDamage;
        EventService.OnStartGame -= PlayStartGame;
        EventService.OnEnemyDieSound -= PlayEnemyDie;
        EventService.OnPlayerJumpSound -= PlayPlayerJump;
        EventService.OnEnemyShotSound -= PlayEnemyShot;
        EventService.OnNotEnoughMoney -= PlayNotEnoughMoney;
        EventService.OnBoosterBuy -= PlayBoosterBuy;
    }
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

    public void PlayAttackSound()
    {
        PlaySound(AttackSound);
    }
    public void PlayEnemyDamage()
    {
        PlaySound(EnemyDamage);
    }

    public void PlayEnemyDie()
    {
        PlaySound(EnemyDie);
    }

    public void PlayStartGame()
    {
        PlaySound(GameStart);
    }
    public void PlayPlayerJump()
    {
        PlaySound(PlayerJump);
    }
    public void PlayEnemyShot()
    {
        PlaySound(EnemyShot);
    }
    public void PlayBoosterBuy()
    {
        PlaySound(BoosterBuy);
    }
    public void PlayNotEnoughMoney()
    {
        PlaySound(NotEnoughMoney);
    }
}
