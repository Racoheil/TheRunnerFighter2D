using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 0.005f;

    private float _lifeTime = 10f;

    private Vector2 _moveVector;

    private void Awake()
    {
        _moveVector = new Vector2(-1, 0);
    }
    private void Start()
    {
        ActivateBulet();
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * _speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!PlayerHealthSystemService.instance.GetImmortality())
            {
                EventService.CallOnTakeDamage();
            }
        }
    }

    private void ActivateBulet()
    {
        StartCoroutine(LifeRoutine());
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSecondsRealtime(_lifeTime);
        this.gameObject.SetActive(false);
    }
}
