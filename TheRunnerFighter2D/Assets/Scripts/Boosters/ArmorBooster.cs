using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBooster : MonoBehaviour, IBooster
{

    [SerializeField] SpriteRenderer ArmorBoosterSprite;

    [SerializeField] private float _activeTime = 25f;

    private bool _isActive;

    private int _boosterNumber = 1;

    public static ArmorBooster instance;

    private void OnEnable()
    {
        EventService.OnArmorBoosterActivate += ActivateBooster;
    }
    private void OnDisable()
    {
        EventService.OnArmorBoosterActivate -= ActivateBooster;
    }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        DeactivateBooster();
    }
    public void ActivateBooster()
    {
        EventService.CallOnBoosterActivateSound();

        StartCoroutine(ActivateBoosterRoutine(_activeTime));
        PlayerHealthSystemService.instance.ImmortalizeThePlayer(_activeTime);
    }

    public void DeactivateBooster()
    {
        _isActive = false;
        ArmorBoosterSprite.enabled = false;
    }
    private IEnumerator ActivateBoosterRoutine(float time)
    {
        _isActive = true;
        ArmorBoosterSprite.enabled = true;
        yield return new WaitForSecondsRealtime(_activeTime);
        DeactivateBooster();
    }

    public bool GetActivity()
    {
        return _isActive;
    }
}
