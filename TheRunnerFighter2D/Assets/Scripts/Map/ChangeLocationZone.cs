using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevelZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("ChangeLevel!!");
            EventService.CallOnPlayerChangeLevel();
            DeactivateChangeZone();
        }
    }
    private void DeactivateChangeZone()
    {
        this.gameObject.SetActive(false);
    }
}
