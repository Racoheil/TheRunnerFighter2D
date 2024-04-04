using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject _targetObject;

    private void FixedUpdate()
    {

        this.transform.position = new Vector3(_targetObject.transform.position.x,this.transform.position.y,this.transform.position.z);
    }
}
