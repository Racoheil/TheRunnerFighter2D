using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger!!");
        if (collision.gameObject.tag == "Player")
        {
            if (!PlayerHealthSystemService.instance.GetImmortality())
            {
                EventService.CallOnTakeDamage();
            }
        }
    }
}
