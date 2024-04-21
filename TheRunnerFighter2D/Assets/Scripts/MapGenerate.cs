using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerate : MonoBehaviour
{

    [SerializeField] private PlatformsGroup[] _1LevelTilesObjects;

    [SerializeField] private PlatformsGroup[] _2LevelTilesObjects;

    private int _currentLevel;
   // [SerializeField] private List<PlatformsGroup> _platformsTiles;

    [SerializeField] private List<PlatformsGroup> _activePlatformsTiles;

    private int _activeTilesCount = 3;

    private bool _isFirstActivePlatform = false;

    private float _defaultPositionY;

    private float _additingValueX;

    private void Awake()
    {
       // _platformsTiles = new List<PlatformsGroup>();
        _activePlatformsTiles = new List<PlatformsGroup>();

        _additingValueX = 330;
        _defaultPositionY = 0;
        _currentLevel = 1;
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
        if (Input.GetKeyUp(KeyCode.L))
        {
            ChangeLevel();
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
        switch (_currentLevel)
        {
            case 1:
                {
                    _1LevelTilesObjects[0].gameObject.SetActive(true);
                    _1LevelTilesObjects[0].transform.position = new Vector3(0, _defaultPositionY);
                    _activePlatformsTiles.Add(_1LevelTilesObjects[0]);
                    _isFirstActivePlatform = true;
                    _1LevelTilesObjects[0].isActive = true;
                    for (int i = 1; i < _activeTilesCount; i++)
                    {
                        _1LevelTilesObjects[i].isActive = true;
                        _1LevelTilesObjects[i].gameObject.SetActive(true);
                        _1LevelTilesObjects[i].transform.position = new Vector3(_1LevelTilesObjects[i - 1].transform.position.x + _additingValueX, _defaultPositionY);
                        _activePlatformsTiles.Add(_1LevelTilesObjects[i]);
                    }
                    break;
                }
            case 2:
                {
                    _2LevelTilesObjects[0].gameObject.SetActive(true);
                    _2LevelTilesObjects[0].transform.position = new Vector3(0, _defaultPositionY);
                    _activePlatformsTiles.Add(_2LevelTilesObjects[0]);
                    _isFirstActivePlatform = true;
                    _2LevelTilesObjects[0].isActive = true;
                    for (int i = 1; i < _activeTilesCount; i++)
                    {
                        _2LevelTilesObjects[i].isActive = true;
                        _2LevelTilesObjects[i].gameObject.SetActive(true);
                        _2LevelTilesObjects[i].transform.position = new Vector3(_2LevelTilesObjects[i - 1].transform.position.x + _additingValueX, _defaultPositionY);
                        _activePlatformsTiles.Add(_1LevelTilesObjects[i]);
                    }
                    break;
                }
        }
        
    }
    private void CreateAllPlatformsGroups()
    {
        for(int i = 0; i < _1LevelTilesObjects.Length; i++)
        {
            _1LevelTilesObjects[i] = Instantiate(_1LevelTilesObjects[i]);
            _1LevelTilesObjects[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _2LevelTilesObjects.Length; i++)
        {
            _2LevelTilesObjects[i] = Instantiate(_2LevelTilesObjects[i]);
            _2LevelTilesObjects[i].gameObject.SetActive(false);
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
            switch(_currentLevel)
            {
                case 1:
                    {
                        _activePlatformsTiles[0].isActive = false;              ///
                        _activePlatformsTiles[0].gameObject.SetActive(false);   ///
                        _activePlatformsTiles.RemoveAt(0);                      ///

                        int randomNumber = GetRandomNumber();
                        _1LevelTilesObjects[randomNumber].isActive = true;
                        _activePlatformsTiles.Add(_1LevelTilesObjects[randomNumber]);


                        _1LevelTilesObjects[randomNumber].gameObject.SetActive(true);
                        _1LevelTilesObjects[randomNumber].transform.position = new Vector3(_activePlatformsTiles[1].transform.position.x + 330, _defaultPositionY);

                        _isFirstActivePlatform = true;
                        break;
                    }
                case 2:
                    {
                        _activePlatformsTiles[0].isActive = false;              ///
                        _activePlatformsTiles[0].gameObject.SetActive(false);   ///
                        _activePlatformsTiles.RemoveAt(0);                      ///

                        int randomNumber = GetRandomNumber();
                        _2LevelTilesObjects[randomNumber].isActive = true;
                        _activePlatformsTiles.Add(_2LevelTilesObjects[randomNumber]);


                        _2LevelTilesObjects[randomNumber].gameObject.SetActive(true);
                        _2LevelTilesObjects[randomNumber].transform.position = new Vector3(_activePlatformsTiles[1].transform.position.x + 330, _defaultPositionY);

                        _isFirstActivePlatform = true;
                        break;
                    }
            }
            
        }

    }
    private int GetRandomNumber()
    {
        switch (_currentLevel)
        {
            case 1:
                {
                    int randomNumber = Random.Range(0, _1LevelTilesObjects.Length - 1);
                    Debug.Log("Random = " + randomNumber);
                    if (_1LevelTilesObjects[randomNumber].isActive)
                    {
                        return GetRandomNumber();
                    }
                    else
                    {
                        Debug.Log($"_platformsTiles[{randomNumber}].isActive = " + _1LevelTilesObjects[randomNumber].isActive);
                        return randomNumber;
                    }
                    
                }
            case 2:
                {
                    int randomNumber = Random.Range(0, _2LevelTilesObjects.Length - 1);
                    Debug.Log("Random = " + randomNumber);
                    if (_2LevelTilesObjects[randomNumber].isActive)
                    {
                        return GetRandomNumber();
                    }
                    else
                    {
                        Debug.Log($"_platformsTiles[{randomNumber}].isActive = " + _2LevelTilesObjects[randomNumber].isActive);
                        return randomNumber;
                    }
                  
                }
            default: return 0;
        }
        
    }

    private void ChangeLevel()
    {
        _currentLevel++;
        _isFirstActivePlatform = true;
        _defaultPositionY = -70;
        GenerateStartPosition();
    }
}
