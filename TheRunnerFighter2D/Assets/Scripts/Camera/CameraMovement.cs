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

    [SerializeField] private float speed = 3.8f;

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
        _defaultPos = transform.position;

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
        else if(_targetObject.position.y > _maxY )
        {
            float interpolation = speed * Time.deltaTime;

            Vector3 position = this.transform.position;
            position.y = Mathf.Lerp(this.transform.position.y, _targetObject.transform.position.y-8, interpolation);
            position.x = Mathf.Lerp(this.transform.position.x, _targetObject.transform.position.x, interpolation);
            this.transform.position = position;
        }
        if (isFollowPlayer)
        {
            print("Follow to player!");
            transform.position = new Vector3(_targetObject.position.x, _targetObject.transform.position.y, transform.position.z);
        }
    }
    private void ChangeCameraPosSmoothly()
    {
        StartCoroutine(FollowPlayerCoroutine());
        
    }
    IEnumerator FollowPlayerCoroutine()
    {
        float addingValueY = MapGenerate.instance.GetAddingValue();
        float followPlayerTime = Mathf.Abs(0.017f * addingValueY);
        print(0.02f + " * " + addingValueY);
        print("Follow player time = " + followPlayerTime);
        isFollowPlayer = true;
        yield return new WaitForSecondsRealtime(followPlayerTime);

        
        _maxY += addingValueY;
        _defaultPos.y += addingValueY;
        isFollowPlayer = false;
    }
}
