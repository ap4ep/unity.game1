using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpawner : MonoBehaviour
{
    [SerializeField] private int _spawnCount;
    [SerializeField] private float _distanceBetweanSpawn;

    public event Action Moved;

    private void Update()
    {
        if(gameObject.activeSelf == true)
            Step();
    }

    private void ChangePosition()
    {
        transform.Translate(Vector3.right * _distanceBetweanSpawn);
        Moved?.Invoke();
    }

    private void Step()
    {
        for (int i = 0; i <= _spawnCount; i++)
        {
            ChangePosition();

            if (i == _spawnCount)
                gameObject.SetActive(false);
        }
    }
}
