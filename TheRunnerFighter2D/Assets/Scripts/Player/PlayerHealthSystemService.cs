using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystemService : MonoBehaviour
{
    private int _health;

    private static int _defaultHealth = 3;

    private static int _minHealth = 1;

    private static int _maxHealth = 6;

    private List<GameObject> _heartsList;

    [SerializeField] private GameObject _heartsPanel;

    [SerializeField] private GameObject _heartPrefab;

    private bool _isImmortal;

    private float _immortalityTime = 3f;

    public static PlayerHealthSystemService instance;

    private void Awake()
    {
        instance = this;
        _isImmortal = false;
        _heartsList = new List<GameObject>();
        _health = _defaultHealth;
        ResetHealth();
    }

    private void OnEnable()
    {
        EventService.OnTakeDamage += TakeDamage;
        EventService.OnTakeDamage += ImmortalizeThePlayer;
    }

    private void OnDisable()
    {
       EventService.OnTakeDamage -= TakeDamage;
       EventService.OnTakeDamage -= ImmortalizeThePlayer;
    }

    public bool GetImmortality()
    {
        return _isImmortal;
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
        if(!_isImmortal)
        {
            _health--;
            _heartsList[_health].gameObject.SetActive(false);

            if (_health == _minHealth-1)
            {
                StartCoroutine(DeathRoutine());
                return;
            }
        }
    }
    
    public void IncreaseHealth()
    {
        _health++;
        _heartsList[_health-1].gameObject.SetActive(true);
    }

    public void ResetHealth()
    {
        _health = _defaultHealth;
        FillHeartsPanel();
    }

    public void FillHeartsPanel()
    {
        CreateAllHeartsObjects();
        for (int i = _maxHealth-1; i > _defaultHealth-1; i--)
        {
            _heartsList[i].gameObject.SetActive(false);
        }
    }

    public void CreateAllHeartsObjects()
    {
        Debug.Log(_maxHealth);      
        for (int i = 0; i < _maxHealth; i++)
        {
            GameObject heart = Instantiate(_heartPrefab);
            heart.transform.SetParent(_heartsPanel.transform);
            heart.transform.localScale = Vector3.one;
            _heartsList.Add(heart);
        }
    }

    private IEnumerator DeathRoutine()
    {
        PlayerAnimation.instance.animator.SetBool("isDead", true);

        yield return new WaitForSeconds(2f);
        EventService.CallOnPlayerLose();
    }
    public void ImmortalizeThePlayer()
    {
        _isImmortal = true;
        Debug.Log("Immortal is activated!!" + _isImmortal);
        StartCoroutine(ImmortalizeCoroutine());
    }

    IEnumerator ImmortalizeCoroutine()
    {
        yield return new WaitForSeconds(_immortalityTime);
        _isImmortal = false;
        Debug.Log("Immortalize is deactivated!!");
    }
}
