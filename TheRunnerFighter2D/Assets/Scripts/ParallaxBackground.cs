using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField, Range(0,1)] private float _speedOfParallax;
    [SerializeField] private float _startPosition;
    private float _lengthOfSprite;
    private Camera _camera;

    void Start()
    {
        _camera = FindObjectOfType<Camera>();
        _startPosition = transform.position.x;
        _lengthOfSprite = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        Vector3 Position = _camera.transform.position;
        //float Temp = Position.x * (1 - _speedOfParallax);
        float Distance = Position.x * _speedOfParallax;
        //_startPosition = transform.position.x;
        Vector3 NewPosition = new Vector3(_startPosition + Distance, transform.position.y, transform.position.z);

        transform.position = NewPosition;
    }
}
