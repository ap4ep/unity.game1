using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Spawner
{
    public override int GetObjectCount(GameObject[] _gameObjects)
    {
        return Random.Range(0, 7);
    }
}
