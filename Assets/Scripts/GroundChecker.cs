using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private GameObject _сheckPoint;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _whatIsGround;

    public bool CheckGround()
    {
        return Physics2D.OverlapCircle(_сheckPoint.transform.position, _radius, _whatIsGround);
    }
}
