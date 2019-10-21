using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjects;
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
        if (Vector2.Distance(_lastSpawnPosition, transform.position) > 10)
        {
            for (int i = 0; i < GetObjectCount(); i++)
            {
                _spawnPosition.x += 1;
                _spawnPosition.y = _spawnPositionY;
                Instantiate(_gameObjects[Random.Range(0, _gameObjects.Length)], _spawnPosition, Quaternion.identity);
                _lastSpawnPosition = transform.position;
            }
        }
    }

    public abstract int GetObjectCount();
}