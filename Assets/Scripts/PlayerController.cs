using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundChecker))]
public class PlayerController : MonoBehaviour
{
    public event Action<int> OnCoinCollect;
    private GroundChecker _groundChecker;
    private Rigidbody2D _rigidbody;
    private float _speed = 4f;
    private float _jumpForce = 10f;
    private float _horizontalMove;
    private int _coins = 0;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponent<GroundChecker>();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            MovePlayer();
        if (Input.GetButtonDown("Jump"))
            JumpPlayer();
    }

    private void MovePlayer()
    {
        if (_groundChecker.CheckGround())
        {
            _horizontalMove = Input.GetAxis("Horizontal");
            _rigidbody.velocity = new Vector2(_horizontalMove * _speed, _rigidbody.velocity.y);
        }
    }

    private void JumpPlayer()
    {
        if (_groundChecker.CheckGround())
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            _coins++;
            OnCoinCollect(_coins);
            Destroy(collision.gameObject);
        }
    }
}
