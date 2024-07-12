using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightBooster : MonoBehaviour, IBooster
{
    [SerializeField] SpriteRenderer FlightBoosterSprite;

    private bool _isActive;

    [SerializeField] private float _activeTime = 25f;

    private int _newJumpsCount = 10;

    private float _newGravityScale = 1;

    private float _newMass = 2.5f;

    private int _boosterNumber = 2;

    private void OnEnable()
    {
        EventService.OnFlightBoosterActivate += ActivateBooster;
    }
    private void OnDisable()
    {
        EventService.OnFlightBoosterActivate -= ActivateBooster;
    }
    private void Awake()
    {
        _isActive = false;
    }

    private void Start()
    {
        FlightBoosterSprite.enabled = false;
    }
    public void ActivateBooster()
    {
        BoostersPanel._instance.UseBooster(_boosterNumber);

        FlightBoosterSprite.enabled = true;
        StartCoroutine(ActivateBoosterRoutine(_activeTime));
    }
    public void DeactivateBooster()
    {
        FlightBoosterSprite.enabled = false;
        _isActive = false;
        PlayerJump.instance.SetDefaultJumpsCount();
        PlayerMovement.instance.SetDefaultRigidBodyPropeties();
        EventService.CallOnFlightBoosterDeactivate();
    }
    private IEnumerator ActivateBoosterRoutine(float time)
    {
        _isActive = true;
        PlayerJump.instance.SetJumpsCount(_newJumpsCount);

        PlayerMovement.instance.SetGravityScale(_newGravityScale);
        PlayerMovement.instance.SetMass(_newMass);
        yield return new WaitForSecondsRealtime(_activeTime);
        DeactivateBooster();
    }
}
