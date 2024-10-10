using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private AudioClip
        ButtonTap,
        AttackSound,
        EnemyDamage,
        EnemyDie,
        GameStart,
        PlayerJump,
        PlayerLanding,
        PlayerDamage,
        BoosterActivate,
        EnemyShot,
        EnemySwing,
        BoosterBuy,
        NotEnoughMoney,
        PlayerLose,
        TrampolineJump;

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
        EventService.OnPlayerLanding += PlayPlayerLanding;
        EventService.OnTakeDamage += PlayPlayerDamage;
        EventService.OnPlayerLose += PlayPlayerLose;
        EventService.OnBoosterActivateSound += PlayBoosterActivate;
        EventService.OnEnemySwingSound += PlayEnemySwing;
        EventService.OnTrampolineJump += PlayTrampolineJump;
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
        EventService.OnPlayerLanding -= PlayPlayerLanding;
        EventService.OnTakeDamage -= PlayPlayerDamage;
        EventService.OnPlayerLose -= PlayPlayerLose;
        EventService.OnBoosterActivateSound -= PlayBoosterActivate;
        EventService.OnEnemySwingSound -= PlayEnemySwing;
        EventService.OnTrampolineJump -= PlayTrampolineJump;
    }
    public void PlaySound(AudioClip audio)
    {
        if (GameDataHolder.GetSoundState() == false) return;
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

    public void PlayPlayerLanding()
    {
        PlaySound(PlayerLanding);
    }

    public void PlayPlayerDamage()
    {
        PlaySound(PlayerDamage);
    }

    public void PlayPlayerLose()
    {
        PlaySound(PlayerLose);
    }

    public void PlayBoosterActivate()
    {
        PlaySound(BoosterActivate);
    }
    public void PlayEnemySwing()
    {
        PlaySound(EnemySwing);
    }
    public void PlayTrampolineJump()
    {
        PlaySound(TrampolineJump);
    }
    public void PlaySoundButtonTap()
    {
        _audioSource.PlayOneShot(ButtonTap);
    }
}
