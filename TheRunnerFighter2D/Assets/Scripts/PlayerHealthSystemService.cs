using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystemService : MonoBehaviour
{
    private int _health;

    private static int _defaultHealth = 3;

    private static int _minHealth = 1;

    private static int _maxHealth = 6;

    [SerializeField] private HeartsPanel _heartsPanel;

    private void Awake()
    {
        _health = _defaultHealth;
        ResetHealth();
    }

    private void OnEnable()
    {
     //   EventService.OnTakeDamage += TakeDamage;
        ResetHealth() ;
    }

    private void OnDisable()
    {
    //    EventService.OnTakeDamage -= TakeDamage;
        ResetHealth();
    }
    public int GetHealth()
    {
        return _health;
    }
    public void TakeDamage()
    {
        ReduceHealth();
        Debug.Log("Health : " + _health);
    }
    public void ReduceHealth()
    {
        _health -= 1;
       // _heartsPanel.ResetHearts();
    }
    
    public void IncreaseHealth()
    {
        _health += 1;
        _heartsPanel.IncreaseHearts();
    }

    public void ResetHealth()
    {
        _health = _defaultHealth;
       // _heartsPanel.ResetHearts();
    }
}
