using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EventService.CallOnTrampolineJump();
        }
    }
}