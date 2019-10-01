using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{

    [SerializeField] private Transform _player;
    [SerializeField] private float _smooth = 1.5f;

    void Update()
    {
        Vector3 destPoint = new Vector3(_player.position.x, transform.position.y, -100);
        transform.position = Vector3.Lerp(transform.position, destPoint, _smooth * Time.deltaTime);
    }
}