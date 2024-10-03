using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevelZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
          //  Debug.Log("ChangeLevel!!");
            EventService.CallOnPlayerChangeLevel();
            DeactivateChangeZone();
        }
        if(collision.gameObject.tag == "Enemy")
        {
            
            collision.gameObject.GetComponent<IEnemy>().Die();

        }
    }
    private void DeactivateChangeZone()
    {
        this.gameObject.SetActive(false);
    }
}
