using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossZone : MonoBehaviour
{
    private float _lossDelay = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            OnPlayerFall();
        }
    }

    private void OnPlayerFall()
    {
        //yield return new WaitForSeconds(_lossDelay);
        PlayerAnimation.instance.animator.SetBool("isDead", true);
        EventService.CallOnPlayerFell();
        EventService.CallOnPlayerLose();
    }

}
