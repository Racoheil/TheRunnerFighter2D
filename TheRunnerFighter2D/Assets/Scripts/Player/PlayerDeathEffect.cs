using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathEffect : MonoBehaviour
{
    ParticleSystem DeathEffect;

    private void OnEnable()
    {
        EventService.OnPlayerLose += ActivateEffect;
    }

    private void OnDisable()
    {
        EventService.OnPlayerLose -= ActivateEffect;           
    }
    private void Awake()
    {
        DeathEffect = GetComponent<ParticleSystem>();

        DeathEffect.Stop();
    }

    private void ActivateEffect()
    {
        DeathEffect.Play();
    }
}
