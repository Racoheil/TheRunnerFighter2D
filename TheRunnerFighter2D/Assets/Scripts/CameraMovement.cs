using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _targetObject;

    private float _minY;

    private float _maxY;

    Vector3 _posEnd, _posSmooth;

    private void Start()
    {
        _minY = _targetObject.transform.position.y - 3;

        _maxY = _targetObject.transform.position.y + 8;
    }
    private void FixedUpdate()
    {
        if(_targetObject.position.y < _maxY)
        {
            this.transform.position = new Vector3(_targetObject.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
        else
        {
            this.transform.position = new Vector3(_targetObject.transform.position.x, _targetObject.transform.position.y - 8, this.transform.position.z);
           // this.transform.position = new Vector3(_targetObject.transform.position.x, this.transform.position.y, this.transform.position.z);
            _posEnd = new Vector3(transform.position.x, _targetObject.transform.position.y-8, this.transform.position.z);

            //_posSmooth = Vector3.Lerp(transform.position, _posEnd, 0.005f);

            //this.transform.position = _posSmooth;
        }
       
    }
}
