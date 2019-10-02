using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private GameObject CheckPoint;
    [SerializeField] private float Radius;
    [SerializeField] private LayerMask WhatIsGround;

    public bool CheckGround()
    {
        return Physics2D.OverlapCircle(CheckPoint.transform.position, Radius, WhatIsGround);
    }
}
