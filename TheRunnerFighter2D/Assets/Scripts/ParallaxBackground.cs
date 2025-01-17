using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField, Range(0,1)] private float _speedOfParallax;
    private float _startPosition;
    private float _lengthOfSprite;

    void Start()
    {
        _startPosition = transform.position.x;
        _lengthOfSprite = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        Vector3 Position = _camera.transform.position;
        float Temp = Position.x * (1 - _speedOfParallax);
        float Distance = Position.x * _speedOfParallax;

        Vector3 NewPosition = new Vector3(_startPosition + Distance, transform.position.y, transform.position.z);

        transform.position = NewPosition;
    }
}
