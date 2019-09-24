using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] _obstraction;
    public GameObject _coin;
    private bool _spawnerIsBusy;
    private Vector2 _spawnPosition;
    private int _coinCount;
    private float _timeBetweanSpawnCoin;
    private float _timeBetweanSpawnObstruction;
    private Vector3 _lastSpawnPositionObstruction = new Vector3();
    private Vector3 _lastSpawnPositionCoin = new Vector3();
    void Start()
    {
        _spawnerIsBusy = false;
        _timeBetweanSpawnCoin = 3.0f;
        _timeBetweanSpawnObstruction = 3.0f;
    }
    void Update()
    {
        _spawnPosition = transform.position;
        ObstractionSpawner();
        CoinSpawner();
    }
    private void CoinSpawner()
    {
        _timeBetweanSpawnCoin -= Time.deltaTime;
        
        if (!_spawnerIsBusy && _timeBetweanSpawnCoin <= 0)
        {
            _spawnerIsBusy = true;
            _coinCount = Random.Range(3, 8);
            Vector2 _positionBetweanSpawn = transform.position - _lastSpawnPositionCoin;
            if(_positionBetweanSpawn.x > 10) { 
                for (int i = 0; i < _coinCount; i++)
                {
                    _spawnPosition.x += 1;
                    _spawnPosition.y = 5;
                    Instantiate(_coin, _spawnPosition, Quaternion.identity);
                    _lastSpawnPositionCoin = transform.position;
                }
            }
            _spawnerIsBusy = false;
            _timeBetweanSpawnCoin = 3.0f;
        }
    }
    private void ObstractionSpawner()
    {
        _timeBetweanSpawnObstruction -= Time.deltaTime;
        if (!_spawnerIsBusy && _timeBetweanSpawnObstruction <= 0)
        {
            _spawnerIsBusy = true;
            Vector2 _positionBetweanSpawn = transform.position - _lastSpawnPositionObstruction;
            if (_positionBetweanSpawn.x > 15)
            {
                _spawnPosition.y -= 0.3f;
                Instantiate(_obstraction[Random.Range(0,3)], _spawnPosition, Quaternion.identity);
                _lastSpawnPositionObstruction = transform.position;
            }
            _spawnerIsBusy = false;
            _timeBetweanSpawnObstruction = 3.0f;
        }
    }
}