using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _targetObject;

   // private float _minY;

    private float _maxY;

    Vector3 _posEnd, _posSmooth;

    private Vector3 _defaultPos;

    private float speed = 3.5f;

    private void Start()
    {
       // _minY = _targetObject.transform.position.y - 3;
        _defaultPos = transform.position;
        //Debug.Log("Default position = " + _defaultPos);
        _maxY = _targetObject.transform.position.y + 6;
    }
    private void Update()
    {
        if(_targetObject.position.y < _maxY)
        {
            float interpolation = speed * Time.deltaTime;
          //  Debug.Log("Interpolation = " + interpolation);
            Vector3 position = this.transform.position;
            position.y = Mathf.Lerp(this.transform.position.y, _defaultPos.y, interpolation);
            //Debug.Log("Interpolation value of position.y = " + position.y);
            position.x = Mathf.Lerp(this.transform.position.x, _targetObject.transform.position.x, interpolation);
            //Debug.Log("Interpolation value of position.x = " + position.x);


            this.transform.position = position;
            //this.transform.position = new Vector3(_targetObject.transform.position.x, _defaultPos.y, this.transform.position.z);
        }
        else
        {
            float interpolation = speed * Time.deltaTime;
            Vector3 position = this.transform.position;
            position.y = Mathf.Lerp(this.transform.position.y, _targetObject.transform.position.y-8, interpolation);
            position.x = Mathf.Lerp(this.transform.position.x, _targetObject.transform.position.x, interpolation);
            this.transform.position = position;
            //this.transform.position = new Vector3(_targetObject.transform.position.x, _targetObject.transform.position.y - 5, this.transform.position.z);
            //_posEnd = new Vector3(this.transform.position.x, _targetObject.transform.position.y-5, this.transform.position.z);


        }
    }
}
