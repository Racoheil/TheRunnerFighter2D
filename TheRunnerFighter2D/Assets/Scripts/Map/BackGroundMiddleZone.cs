using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMiddleZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Player on middle of background!");
        if (collision.tag == "Player")
        {
            EventService.CallOnPlayerReachedBackgroundMiddle();
           // Debug.Log("Player on middle of background!");
        }
    }
    
}
