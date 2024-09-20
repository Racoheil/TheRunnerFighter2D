using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyUpOnDeath : MonoBehaviour
{
    [SerializeField] private float _flyHeight;
    [SerializeField] private float _flyDuration;

    private bool _isPlayerFell;

    Rigidbody2D _rigidBody;

    private Transform _gameObject;

    private void OnEnable()
    {
        EventService.OnPlayerLose += FlyUp;
        EventService.OnPlayerFell += DoOnPlayerFell;
    }
    private void OnDisable()
    {
        EventService.OnPlayerLose -= FlyUp;
        EventService.OnPlayerFell -= DoOnPlayerFell;
    }
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();

        _gameObject = this.transform;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FlyUp();
        }
    }
    private void FlyUp()
    {
        if (_isPlayerFell) return;
        _gameObject.DOMoveY(transform.position.y + _flyHeight, _flyDuration);
        _rigidBody.simulated = false;
    }
    private void DoOnPlayerFell()
    {
        _isPlayerFell = true;
    }
}
