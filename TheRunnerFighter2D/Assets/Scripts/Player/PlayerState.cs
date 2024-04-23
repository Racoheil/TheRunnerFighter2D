using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static PlayerState instance;

    private void Awake()
    {
        instance = this;
    }

    public Vector3 GetPlayerPosition()
    {
        return this.transform.position;
    }
}
