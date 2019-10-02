using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public int Coins => _coins;
    public UnityEvent CoinCollected;

    private GroundChecker _groundChecker;
    private float _speed = 4f;
    private float _jumpForce = 10f;
    private Rigidbody2D _rigidbody;
    private float _horizontalMove;
    private int _coins;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponent<GroundChecker>();
        _coins = 0;
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
            CoinCollected.Invoke();
            Destroy(collision.gameObject);
        }
    }
}
