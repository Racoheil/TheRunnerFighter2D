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
        PlayerDeath;

    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        EventService.OnAttackSound += PlayAttackSound;
        EventService.OnEnemyTakeDamageSound += PlayEnemyDamage;
    }
    private void OnDisable()
    {
        EventService.OnAttackSound -= PlayAttackSound;
        EventService.OnEnemyTakeDamageSound -= PlayEnemyDamage;
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
}
