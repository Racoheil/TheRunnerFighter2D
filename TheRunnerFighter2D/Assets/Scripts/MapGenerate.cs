using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerate : MonoBehaviour
{

    [SerializeField] private PlatformsGroup[] _platformsTilesObjects;

    [SerializeField] private List<PlatformsGroup> _platformsTiles;

    [SerializeField] private List<PlatformsGroup> _activePlatformsTiles;

    private int _activeTilesCount = 3;

    private bool _isFirstActivePlatform = false;

    private float _additingValueY;

    private float _additingValueX;

    private void Awake()
    {
        _platformsTiles = new List<PlatformsGroup>();
        _activePlatformsTiles = new List<PlatformsGroup>();

        _additingValueX = 330;
        _additingValueY = 0;
    }
    private void Start()
    {
        _isFirstActivePlatform = true;
        CreateAllPlatformsGroups();
        GenerateStartPosition();
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.H))
        {
            GenerateMap();
        }
    }

    private void OnEnable()
    {
        EventService.OnPlayerFinishingPlatform += GenerateMap;
    }
    private void OnDisable()
    {
        EventService.OnPlayerFinishingPlatform -= GenerateMap;
    }
    private void GenerateStartPosition()
    {
        _platformsTiles[0].gameObject.SetActive(true);
        _platformsTiles[0].transform.position = Vector3.zero;
        _activePlatformsTiles.Add(_platformsTiles[0]);
        _isFirstActivePlatform = true;
        _platformsTiles[0].isActive = true;
        for (int i = 1; i < _activeTilesCount; i++)
        {
            _platformsTiles[i].isActive = true;
            _platformsTiles[i].gameObject.SetActive(true);
            _platformsTiles[i].transform.position = _platformsTiles[i - 1].transform.position + new Vector3(_additingValueX, _additingValueY, 0);
            _activePlatformsTiles.Add(_platformsTiles[i]);
        }
    }
    private void CreateAllPlatformsGroups()
    {
        for(int i = 0; i< _platformsTilesObjects.Length; i++)
        {
            PlatformsGroup platform = Instantiate(_platformsTilesObjects[i]);

            _platformsTiles.Add(platform);

            platform.gameObject.SetActive(false);
            
            
        }
    }

    private void GenerateMap()
    {

        if (_isFirstActivePlatform == true)
        {
            _isFirstActivePlatform = false;
        }
        else if (_isFirstActivePlatform == false)
        {
            _activePlatformsTiles[0].isActive = false;              ///
            _activePlatformsTiles[0].gameObject.SetActive(false);   ///
            _activePlatformsTiles.RemoveAt(0);                      ///

            int randomNumber = GetRandomNumber();
            _platformsTiles[randomNumber].isActive = true;
            _activePlatformsTiles.Add(_platformsTiles[randomNumber]);


            _platformsTiles[randomNumber].gameObject.SetActive(true);
            _platformsTiles[randomNumber].transform.position = _activePlatformsTiles[1].transform.position + new Vector3(330, 0, 0);

            _isFirstActivePlatform = true;
        }

    }
    private int GetRandomNumber()
    {

        int randomNumber = Random.Range(0, _platformsTiles.Count - 1);
        Debug.Log("Random = " + randomNumber);
        if (_platformsTiles[randomNumber].isActive)
        {
            return GetRandomNumber();
        }
        else 
        {
            Debug.Log($"_platformsTiles[{randomNumber}].isActive = " + _platformsTiles[randomNumber].isActive);
            return randomNumber;
        }
    }
}
