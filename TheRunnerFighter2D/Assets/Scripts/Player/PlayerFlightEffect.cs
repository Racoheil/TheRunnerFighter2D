using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlightEffect : MonoBehaviour
{
    ParticleSystem FlightEffect;

    private void Awake()
    {
        FlightEffect = GetComponent<ParticleSystem>();

        FlightEffect.Stop();
    }
    private void OnEnable()
    {
        EventService.OnFlightBoosterActivate += ActivateEffect;
        EventService.OnFlightBoosterDeactivate += DeactivateEffect;
    }
    private void OnDisable()
    {
        EventService.OnFlightBoosterActivate -= ActivateEffect;
        EventService.OnFlightBoosterDeactivate -= DeactivateEffect;
    }
    public void ActivateEffect()
    {
        FlightEffect.Play();
    }
    public void DeactivateEffect()
    {
        FlightEffect.Stop();
    }

}
