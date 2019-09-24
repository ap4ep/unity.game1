using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform Player;
    [SerializeField]
    private float smooth = 1.5f;

    void Update()
    {
        Vector3 destPoint = new Vector3(Player.position.x, transform.position.y, -100);
        transform.position = Vector3.Lerp(transform.position, destPoint, smooth * Time.deltaTime);
    }
}