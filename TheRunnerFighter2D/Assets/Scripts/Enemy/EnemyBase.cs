using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase 
{
    private void StartAttack()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TriggerZone")
        {
            StartAttack();
        }
    }
}
