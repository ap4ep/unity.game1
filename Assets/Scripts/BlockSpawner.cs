using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : Spawner
{
    public override int GetObjectCount(GameObject[] _gameObjects)
    {
        return 1;
    }
}
