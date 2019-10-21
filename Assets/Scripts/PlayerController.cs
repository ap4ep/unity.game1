using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundChecker))]
public class PlayerController : MonoBehaviour
{
    public event Action<int> CoinCollect;

    private GroundChecker _groundChecker;
    private Rigidbody2D _rigidbody;
    private float _speed = 4f;
    private float _jumpForce = 10f;
    private float _horizontalInput;
    private int _coins = 0;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponent<GroundChecker>();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            TryMove();
        if (Input.GetButtonDown("Jump"))
            TryJump();
    }

    private void TryMove()
    {
        if (_groundChecker.CheckGround())
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            _rigidbody.velocity = new Vector2(_horizontalInput * _speed, _rigidbody.velocity.y);
        }
    }

    private void TryJump()
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
            CoinCollect?.Invoke(_coins);
            Destroy(collision.gameObject);
        }
    }
}
