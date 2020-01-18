using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;

    private int _score = 0;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        EventManager.Instance.OnPlayerJumpAction += Jump;
        EventManager.Instance.OnBlockStopedAction += AddScore;
    }

    private void AddScore(bool add)
    {
        if (add)
        {
            _score++;
        }
    }

    private void Update()
    {
        if(Mathf.Abs(transform.position.x) >= 0.001f)
        {
            Lose();
        }
    }

    private void Lose()
    {
        if(PlayerPrefs.GetInt("BestScore",0) < _score)
        {
            PlayerPrefs.SetInt("BestScore", _score);
        }
        EventManager.Instance.OnLoseAction?.Invoke(_score);
        Destroy(this);
    }

    private void Jump()
    {
        if (_rigidbody2D.velocity == Vector2.zero)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isGrounded = false;
        }
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnPlayerJumpAction -= Jump;
    }

}
