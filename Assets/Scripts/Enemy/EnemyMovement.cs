using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;

    private Rigidbody2D _rigidbody;
    private PlayerAwarenessController _playerAwarenessController;
    private Vector2 _targetDirection;

    public bool moving;
    public Animator animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
    }

    private void Update()
    {
        UpdateTargetDirection();
        Animate();
    }

    private void FixedUpdate()
    {
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        if (_playerAwarenessController != null && _playerAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer.normalized;
        }
        else
        {
            _targetDirection = Vector2.zero;
        }
    }

    private void SetVelocity()
    {
        _rigidbody.velocity = _targetDirection * _speed;
    }

    private void Animate()
    {
        Vector2 currentVelocity = _rigidbody.velocity;

        if (currentVelocity.magnitude > 0.1f)
        {
            animator.SetBool("Moving", true);
            moving = true;

            animator.SetFloat("x", currentVelocity.x);
            animator.SetFloat("y", currentVelocity.y);
        }
        else
        {
            animator.SetBool("Moving", false);
            moving = false;
        }
    }
}