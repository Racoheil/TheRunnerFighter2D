using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _targetObject;

    private float _minY;

    private float _maxY;

    Vector3 _posEnd, _posSmooth;

    private Vector3 _defaultPos;

    private float speed = 3.8f;

    private bool isFollowPlayer = false;

    private void OnEnable()
    {
        EventService.OnPlayerChangeLevel += ChangeCameraPosSmoothly;
    }
    private void OnDisable()
    {
        EventService.OnPlayerChangeLevel -= ChangeCameraPosSmoothly;
    }
    private void Start()
    {
       // _minY = _targetObject.transform.position.y - 3;
        _defaultPos = transform.position;
        //Debug.Log("Default position = " + _defaultPos);
        _maxY = _targetObject.transform.position.y + 6;

        _minY = _targetObject.transform.position.y - 6;
    }
    private void Update()
    {
        if(_targetObject.position.y < _maxY )
        {
            float interpolation = speed * Time.deltaTime;
          
            Vector3 position = this.transform.position;
            position.y = Mathf.Lerp(this.transform.position.y, _defaultPos.y, interpolation); 
            position.x = Mathf.Lerp(this.transform.position.x, _targetObject.transform.position.x, interpolation);
            this.transform.position = position;
        }
        else 
        {
            float interpolation = speed * Time.deltaTime;

            Vector3 position = this.transform.position;
            position.y = Mathf.Lerp(this.transform.position.y, _targetObject.transform.position.y-8, interpolation);
            position.x = Mathf.Lerp(this.transform.position.x, _targetObject.transform.position.x, interpolation);
            this.transform.position = position;
        }
        if (isFollowPlayer)
        {
            //float interpolation = 2 * speed * Time.deltaTime;

            //Vector3 position = this.transform.position;
            //position.y = Mathf.Lerp(this.transform.position.y, _targetObject.transform.position.y + 8, interpolation);
            //position.x = Mathf.Lerp(this.transform.position.x, _targetObject.transform.position.x, interpolation);
            //this.transform.position = position;
            transform.position = new Vector3(transform.position.x, _targetObject.transform.position.y+4, transform.position.z);
        }
        //if(_targetObject.position.y < _minY)
        //{
        //    float interpolation = speed * Time.deltaTime;
        //    Vector3 position = this.transform.position;
        //    position.y = Mathf.Lerp(this.transform.position.y, _targetObject.transform.position.y, interpolation);
        //    position.x = Mathf.Lerp(this.transform.position.x, _targetObject.transform.position.x, interpolation);
        //    this.transform.position = position;
        //}
    }
    private void ChangeCameraPosSmoothly()
    {
       // float newMaxY = _maxY -= 70f;
        //float newDefaultY = _defaultPos.y - 70f;
       // float changeYSpeed = 75f;
        
        //StartCoroutine(SmoothlyChangeDefaultY(newDefaultY, changeYSpeed));
        StartCoroutine(FollowPlayerCoroutine());
       //StartCoroutine(SmoothlyChangeMaxY(newMaxY, changeYSpeed));
        
    }
    IEnumerator SmoothlyChangeDefaultY(float newDefaultY, float changeSpeed)
    {
        while (_defaultPos.y != newDefaultY)
        {
            _maxY -= 70f;
            yield return new WaitForSecondsRealtime(1f / changeSpeed);
        }
        _maxY -= 70f;
    }
    IEnumerator FollowPlayerCoroutine()
    {
        isFollowPlayer = true;
        print("Follow Player!!");
        yield return new WaitForSecondsRealtime(1.2f);
        print("Don't follow player!!");
        _maxY -= 70f;
        _defaultPos.y -= 70f;
        isFollowPlayer = false;
    }
}
