using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] _gameObjects;

    private bool _spawnerIsBusy;
    [SerializeField] private float _timeBetweanSpawn;
    [SerializeField] private float _spawnPositionY;
    private Vector2 _spawnPosition;
    private Vector3 _lastSpawnPosition = new Vector3();

    void Start()
    {
        _spawnerIsBusy = false;
    }

    void Update()
    {
        _spawnPosition = transform.position;
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        _timeBetweanSpawn -= Time.deltaTime;

        if (!_spawnerIsBusy && _timeBetweanSpawn <= 0)
        {
            _spawnerIsBusy = true;
            Vector2 _positionBetweanSpawn = transform.position - _lastSpawnPosition;

            if (_positionBetweanSpawn.x > 10)
            {
                for (int i = 0; i < GetObjectCount(_gameObjects); i++)
                {
                    _spawnPosition.x += 1;
                    _spawnPosition.y = _spawnPositionY;
                    Instantiate(_gameObjects[Random.Range(0, _gameObjects.Length)], _spawnPosition, Quaternion.identity);
                    _lastSpawnPosition = transform.position;
                }
            }

            _spawnerIsBusy = false;
            _timeBetweanSpawn = 3.0f;
        }
    }

    private int GetObjectCount(GameObject[] _gameObjects)
    {
        if (_gameObjects.Length == 1)
            return Random.Range(3, 8);
        else
            return 1;
    }
}