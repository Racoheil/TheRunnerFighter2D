using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerate : MonoBehaviour
{
    //[SerializeField] private GameObject[] _platformsGroupsPrefabs;

    [SerializeField] private PlatformsGroup[] _platformsTilesObjects;

    [SerializeField] private List<PlatformsGroup> _platformsTiles;

    [SerializeField] private List<PlatformsGroup> _activePlatformsTiles;

    private int _activeTilesCount = 3;

    private int _activeTileNumber;

    private void Awake()
    {
        _platformsTiles = new List<PlatformsGroup>();
        _activePlatformsTiles = new List<PlatformsGroup>();
    }
    private void Start()
    {
        _activeTileNumber = 0;
        CreateAllPlatformsGroups();
        GenerateStartPosition();
       
      //  GenerateStartPosition();
        //GenerateMap();  
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.H))
        {
            GenerateMap();
        }
    }
    //private void Start()
    //{
    //    _platformsGroupsObjects = new PlatformsGroup[_platformsGroupsPrefabs.Length];
    //    Debug.Log("_platformsGroupsPrefabs.Length=" + _platformsGroupsPrefabs.Length);
    //    Debug.Log("_platformsGroupsObjects.Length=" + _platformsGroupsObjects.Length);
    //    _fillPlatfromsGroupsObjects();
    //}
    //private void _fillPlatfromsGroupsObjects()
    //{
    //    for(int i = 0;i < _platformsGroupsPrefabs.Length; i++)
    //    {
    //        _platformsGroupsObjects[i] = new PlatformsGroup(_platformsGroupsPrefabs[i],true);
    //       // _platformsGroupsObjects[i].prefab = _platformsGroupsPrefabs[i].gameObject;
    //    }
    //}

    private void GenerateStartPosition()
    {
        _platformsTiles[0].gameObject.SetActive(true);
        _platformsTiles[0].transform.position = Vector3.zero;
        _activePlatformsTiles.Add(_platformsTiles[0]);
        _activeTileNumber = 0;
        _platformsTiles[0].isActive = true;
        for (int i = 1; i < _activeTilesCount; i++)
        {
            _platformsTiles[i].isActive = true;
            _platformsTiles[i].gameObject.SetActive(true);
            _platformsTiles[i].transform.position = _platformsTiles[i - 1].transform.position + new Vector3(330, 0, 0);
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

        Debug.Log("ActiveTilesNumber = " + _activeTileNumber);
        if (_activeTileNumber == 0)
        {
            _activeTileNumber++;
        }
        else if (_activeTileNumber == 1)
        {
            _activePlatformsTiles[0].isActive = false;
            _activePlatformsTiles[0].gameObject.SetActive(false);
            _activePlatformsTiles.RemoveAt(0);

            //int randomNumber = Random.Range(0, _platformsTiles.Count-1);
            int randomNumber = GetRandomNumber();
            Debug.Log("Random = " + randomNumber);
            _activePlatformsTiles.Add(_platformsTiles[randomNumber]);

            _platformsTiles[randomNumber].isActive = true;
            _platformsTiles[randomNumber].gameObject.SetActive(true);
           
            _platformsTiles[randomNumber].transform.position = _activePlatformsTiles[1].transform.position + new Vector3(330, 0, 0);
            



             _activeTileNumber--;
            
            //_activePlatformsTiles.RemoveAt(_activePlatformsTiles.Count - 1);
        }
        else if( _activeTileNumber == 2)
        {
            _activeTileNumber = 0;

        }

    }
    private int GetRandomNumber()
    {
        int randomNumber = Random.Range(0, _platformsTiles.Count - 1);
        if (_platformsTiles[randomNumber].isActive)
        {
            GetRandomNumber();
        }
        return randomNumber;
        
    }
}
