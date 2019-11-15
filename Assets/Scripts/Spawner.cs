using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveSpawner))]
public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _variants;

    private Vector2 _spawnPosition;
    private MoveSpawner _moveSpawner;

    private void Start()
    {
        _moveSpawner = GetComponent<MoveSpawner>();
        _moveSpawner.Moved += SpawnObjects;
    }

    private void SpawnObjects()
    {
        _spawnPosition = transform.position;

        for (int i = 0; i < GetObjectCount(); i++)
        {
            _spawnPosition.x += 1;
            Instantiate(_variants[Random.Range(0, _variants.Length)], _spawnPosition, Quaternion.identity);
        }
    }

    public abstract int GetObjectCount();
}