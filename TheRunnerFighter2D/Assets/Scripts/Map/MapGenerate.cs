using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerate : MonoBehaviour
{

    [SerializeField] private PlatformsGroup[] _1LevelTilesObjects;

    [SerializeField] private PlatformsGroup[] _2LevelTilesObjects;

    [SerializeField] private PlatformsGroup[] _3LevelTilesObjects;

    private int _currentLevel;

    [SerializeField] private List<PlatformsGroup> _activePlatformsTiles;

    [SerializeField] private List<PlatformsGroup> _inactivePlatformsTiles;

    private int _activeTilesCount = 3;

    private bool _isFirstActivePlatform = false;

    private float _defaultPositionY;    // Defautl position of camera

    private float _addingValueX;        // Additing value for next tile position 

    private float addingValueY = -30;   // Additing value for next level tile position

    public static MapGenerate instance; // SingleTon pattern

    private void Awake()
    {
        instance = this;

        _activePlatformsTiles = new List<PlatformsGroup>();
        _inactivePlatformsTiles = new List<PlatformsGroup>();

        _addingValueX = 330;
        _defaultPositionY = 0;
        _currentLevel = 1;
    }
    private void Start()
    {
        _isFirstActivePlatform = true;

        CreateAllPlatformsGroups();
        
        GenerateStartPosition();
    }

    private void OnEnable()
    {
        EventService.OnPlayerFinishingPlatform += GenerateMap;
        EventService.OnPlayerChangeLevel += ChangeLevel;    
    }
    private void OnDisable()
    {
        EventService.OnPlayerFinishingPlatform -= GenerateMap;
        EventService.OnPlayerChangeLevel -= ChangeLevel;
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
                        _1LevelTilesObjects[i].transform.position = new Vector3(_1LevelTilesObjects[i - 1].transform.position.x + _addingValueX, _defaultPositionY);
                        _activePlatformsTiles.Add(_1LevelTilesObjects[i]);
                    }
                    break;
                }
            case 2:
                {
                    FillInactiveTilesList();
                    _activePlatformsTiles.Clear();

                    _2LevelTilesObjects[0].gameObject.SetActive(true);
                    _2LevelTilesObjects[0].transform.position = new Vector3(PlayerState.instance.GetPlayerPosition().x + 70, _defaultPositionY);
                    _activePlatformsTiles.Add(_2LevelTilesObjects[0]);
                    _isFirstActivePlatform = true;
                    _2LevelTilesObjects[0].isActive = true;
                    for (int i = 1; i < _activeTilesCount; i++)
                    {
                        _2LevelTilesObjects[i].isActive = true;
                        _2LevelTilesObjects[i].gameObject.SetActive(true);
                        _2LevelTilesObjects[i].transform.position = new Vector3(_2LevelTilesObjects[i - 1].transform.position.x + _addingValueX, _defaultPositionY);
                        _activePlatformsTiles.Add(_2LevelTilesObjects[i]);
                    }
                    break;
                }
            case 3:
                {
                    FillInactiveTilesList();
                    _activePlatformsTiles.Clear();

                    _3LevelTilesObjects[0].gameObject.SetActive(true);
                    _3LevelTilesObjects[0].transform.position = new Vector3(PlayerState.instance.GetPlayerPosition().x + 70, _defaultPositionY);
                    _activePlatformsTiles.Add(_3LevelTilesObjects[0]);
                    _isFirstActivePlatform = true;
                    _3LevelTilesObjects[0].isActive = true;
                    for (int i = 1; i < _activeTilesCount; i++)
                    {
                        _3LevelTilesObjects[i].isActive = true;
                        _3LevelTilesObjects[i].gameObject.SetActive(true);
                        _3LevelTilesObjects[i].transform.position = new Vector3(_3LevelTilesObjects[i - 1].transform.position.x + _addingValueX, _defaultPositionY);
                        _activePlatformsTiles.Add(_3LevelTilesObjects[i]);
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
        for (int i = 0; i < _3LevelTilesObjects.Length; i++)
        {
            _3LevelTilesObjects[i] = Instantiate(_3LevelTilesObjects[i]);
            _3LevelTilesObjects[i].gameObject.SetActive(false);
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
                case 3:
                    {
                        _activePlatformsTiles[0].isActive = false;              ///
                        _activePlatformsTiles[0].gameObject.SetActive(false);   ///
                        _activePlatformsTiles.RemoveAt(0);                      ///

                        int randomNumber = GetRandomNumber();
                        _3LevelTilesObjects[randomNumber].isActive = true;
                        _activePlatformsTiles.Add(_3LevelTilesObjects[randomNumber]);


                        _3LevelTilesObjects[randomNumber].gameObject.SetActive(true);
                        _3LevelTilesObjects[randomNumber].transform.position = new Vector3(_activePlatformsTiles[1].transform.position.x + 330, _defaultPositionY);

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
            case 3:
                {
                    int randomNumber = Random.Range(0, _3LevelTilesObjects.Length - 1);
                    Debug.Log("Random = " + randomNumber);
                    if (_3LevelTilesObjects[randomNumber].isActive)
                    {
                        return GetRandomNumber();
                    }
                    else
                    {
                        Debug.Log($"_platformsTiles[{randomNumber}].isActive = " + _3LevelTilesObjects[randomNumber].isActive);
                        return randomNumber;
                    }

                }
            default: return 0;
        }
        
    }
    private IEnumerator DeactivateInactiveTilesCoroutine()
    {
        yield return new WaitForSecondsRealtime(2f);

        foreach (PlatformsGroup item in _inactivePlatformsTiles)
        {
            item.gameObject.SetActive(false);
        }
    }
    private void DeactivateInactiveTiles()
    {
        StartCoroutine(DeactivateInactiveTilesCoroutine());
    }
    private void FillInactiveTilesList()
    {
        for (int i = 0; i < _activePlatformsTiles.Count; i++)
        {
            _inactivePlatformsTiles.Add(_activePlatformsTiles[i]);
        }
    }
    private void ChangeLevel()
    {
        _currentLevel++;
        _isFirstActivePlatform = true;
        _defaultPositionY += addingValueY;
        GenerateStartPosition();
        DeactivateInactiveTiles();
        
    }
    public float GetAddingValue()
    {
        return addingValueY;
    }
   
}
