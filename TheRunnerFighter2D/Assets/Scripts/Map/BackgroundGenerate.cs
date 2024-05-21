using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBackground : MonoBehaviour
{
    [SerializeField] GameObject _backgroundTileObject;

    [SerializeField] private GameObject[] _backgroundTiles;

    private int _tilesCount = 2;

    private bool _isFirstTile;

    private float _addingValueX = 380f;

    private void OnEnable()
    {
        EventService.OnPlayerReachedBackgroundMiddle += GenerateTiles;
    }
    private void OnDisable()
    {
        EventService.OnPlayerReachedBackgroundMiddle -= GenerateTiles;
    }
    private void Awake()
    {
        _backgroundTiles = new GameObject[_tilesCount];
        _isFirstTile = true;
        GenerateStartingTiles();
    }

    public void GenerateStartingTiles()
    {
        CreateAllBackgroundTiles();
        _backgroundTiles[0].SetActive(true);
        _backgroundTiles[0].transform.position = new Vector3(0, 0, 0);
        for (int i = 1; i < _backgroundTiles.Length; i++)
        {
            _backgroundTiles[i].SetActive(true);
            _backgroundTiles[i].transform.position = new Vector3(_backgroundTiles[i - 1].transform.position.x + _addingValueX, 0, 0);
        }
    }
    public void CreateAllBackgroundTiles()
    {
        for(int i = 0; i < _tilesCount; i++)
        {
            _backgroundTiles[i] = Instantiate(_backgroundTileObject);
            _backgroundTiles[i].SetActive(false);
        }
    }
    public void GenerateTiles()
    {
        if (_isFirstTile)
        {
            _isFirstTile = false;
            return;
        }
        else
        {
            _backgroundTiles[0].transform.position = new Vector2(_backgroundTiles[1].transform.position.x + _addingValueX, 0);

            var temp = new GameObject();
            temp = _backgroundTiles[1];
            _backgroundTiles[1] = _backgroundTiles[0];
            _backgroundTiles[0] = temp;

            //_isFirstTile = true;
        }
    }
}
