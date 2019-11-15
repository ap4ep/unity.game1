using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 1.5f;

    void Update()
    {
        Vector3 destinationPoint = new Vector3(_target.position.x, transform.position.y, -100);
        transform.position = Vector3.Lerp(transform.position, destinationPoint, _speed * Time.deltaTime);
    }
}