using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.ParticleSystem;


public class PlatformsGroup : MonoBehaviour 
{
    public bool isActive;

    public GameObject prefab;

    public bool isCurrentPlatform;

    private void Awake()
    {
        PlatformsGroup platformsGroup = new PlatformsGroup(prefab, false);
        prefab = GetComponent<GameObject>();
        isActive = false;
    }
    public PlatformsGroup(GameObject _prefab, bool _isActive)
    {
        prefab = _prefab;
        isActive = _isActive;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isCurrentPlatform = true;
            isActive = true;

            EventService.CallOnPlayerFinishingPlatform();
        }
    }


}
