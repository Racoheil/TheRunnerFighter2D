using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightBonus : MonoBehaviour, IBonus
{
    private bool _isActive;

    [SerializeField] private float _activeTime = 25f;

    private int _newJumpsCount = 10;

    private float _newGravityScale = 1;

    private float _newMass = 2.5f;

    private void OnEnable()
    {
        EventService.OnFlightBonusActivate += ActivateBonus;
    }
    private void OnDisable()
    {
        EventService.OnFlightBonusActivate -= ActivateBonus;
    }
    private void Awake()
    {
        _isActive = false;
    }
    public void ActivateBonus()
    {
        StartCoroutine(ActivateBonusRoutine(_activeTime));
    }
    public void DeactivateBonus()
    {
        _isActive = false;
        PlayerJump.instance.SetDefaultJumpsCount();
        PlayerMovement.instance.SetDefaultRigidBodyPropeties();
        EventService.CallOnFlightBonusDeactivate();
    }
    private IEnumerator ActivateBonusRoutine(float time)
    {
        _isActive = true;
        PlayerJump.instance.SetJumpsCount(_newJumpsCount);

        PlayerMovement.instance.SetGravityScale(_newGravityScale);
        PlayerMovement.instance.SetMass(_newMass);
        yield return new WaitForSecondsRealtime(_activeTime);
        DeactivateBonus();
    }
}
