using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishingZone : MonoBehaviour
{
    private Transform PlatformsTile;

    private void Awake()
    {
        PlatformsTile = this.gameObject.transform.parent;
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        isCurrentPlatform = true;
    //        isActive = true;
    //        Debug.Log("Player on platform!!");
    //        EventService.CallOnPlayerFinishingPlatform();
    //    }
    //}
}
