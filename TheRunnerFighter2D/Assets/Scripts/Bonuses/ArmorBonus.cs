using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBonus : MonoBehaviour, IBonus
{

    [SerializeField] SpriteRenderer ArmorBonusSprite;

    private bool _isActive;

    [SerializeField] private float _activeTime = 25f;

    private void OnEnable()
    {
        EventService.OnArmorBonusActivate += ActivateBonus;
    }
    private void OnDisable()
    {
        EventService.OnArmorBonusActivate -= ActivateBonus;
    }
    private void Awake()
    {

    }
    private void Start()
    {
        DeactivateBonus();
    }
    public void ActivateBonus()
    {
        StartCoroutine(ActivateBonusRoutine(_activeTime));
        PlayerHealthSystemService.instance.ImmortalizeThePlayer(_activeTime);
    }

    public void DeactivateBonus()
    {
        _isActive = false;
        ArmorBonusSprite.enabled = false;
    }
    private IEnumerator ActivateBonusRoutine(float time)
    {
        _isActive = true;
        ArmorBonusSprite.enabled = true;
        yield return new WaitForSecondsRealtime(_activeTime);
        DeactivateBonus();
    }
}
