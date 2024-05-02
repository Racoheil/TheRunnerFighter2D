using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public static PlayerPosition instance;

    private void Awake()
    {
        instance = this;
    }

    public Vector3 GetPlayerPosition()
    {
        return this.transform.position;
    }
}
