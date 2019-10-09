using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjects;
    [SerializeField] private float _timeBetweanSpawn = 3.0f;
    [SerializeField] private float _spawnPositionY;

    private Vector2 _spawnPosition;
    private Vector3 _lastSpawnPosition = new Vector3();

    void Update()
    {
        _spawnPosition = transform.position;
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        _timeBetweanSpawn -= Time.deltaTime;

        if (_timeBetweanSpawn <= 0)
        {
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
            _timeBetweanSpawn = 3.0f;
        }
    }

    public abstract int GetObjectCount(GameObject[] _gameObjects);
}