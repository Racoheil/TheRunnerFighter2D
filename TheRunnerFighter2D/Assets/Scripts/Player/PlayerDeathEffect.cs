using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathEffect : MonoBehaviour
{
    ParticleSystem DeathEffect;

    private bool _isPlayerFell;
    private void OnEnable()
    {
        EventService.OnPlayerLose += ActivateEffect;
        EventService.OnPlayerFell += DoOnPlayerFell;
    }

    private void OnDisable()
    {
        EventService.OnPlayerLose -= ActivateEffect;
        EventService.OnPlayerFell -= DoOnPlayerFell;

    }
    private void Awake()
    {
        _isPlayerFell = false;

        DeathEffect = GetComponent<ParticleSystem>();

        DeathEffect.Stop();
    }

    private void DoOnPlayerFell()
    {
        _isPlayerFell = true;
    }
    private void ActivateEffect()
    {
        if(_isPlayerFell) return;
        DeathEffect.Play();
    }
}
