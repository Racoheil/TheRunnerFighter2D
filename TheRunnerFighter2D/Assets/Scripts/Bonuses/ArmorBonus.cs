using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBonus : MonoBehaviour
{

    [SerializeField] SpriteRenderer ArmorBonusSprite;

    private bool _isActive;

    private float _activeTime = 25f;

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
    private void ActivateBonus()
    {
        StartCoroutine(ArmorBonusRoutine());
        PlayerHealthSystemService.instance.ImmortalizeThePlayer(_activeTime);
    }

    private void DeactivateBonus()
    {
        _isActive = false;
        ArmorBonusSprite.enabled = false;
    }
    private IEnumerator ArmorBonusRoutine()
    {
        _isActive = true;
        ArmorBonusSprite.enabled = true;
        yield return new WaitForSecondsRealtime(_activeTime);
        DeactivateBonus();
    }
}
