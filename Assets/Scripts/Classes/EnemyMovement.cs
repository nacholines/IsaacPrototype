using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IFlippable
{
    public float Within_range;
    public float Speed = 4.5f;
    private Transform target;
    public bool _isChasing;
    public Vector3 CurrentPosition;
    public Vector3 PreviousPosition;
    private bool _isFlipped;

    private MovementAnimationStatus _status;
    private MovementAnimationController _controller;

    void Awake()
    {
        GameManager.StartEnemyChase += StartChase;
        GameManager.StopEnemyChase += StopChase;
        _controller = GetComponent<MovementAnimationController>();
        _status = new MovementAnimationStatus();
    }

    private void Update()
    {
        PreviousPosition = CurrentPosition;

        if (!_isChasing)
        {
            Speed = 0;
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Speed);
        CurrentPosition = transform.position;
        CheckMovementDirection();
    }

    private void LateUpdate()
    {
        _controller.SendAnimationStatus(_status);
    }

    private void StartChase(Transform _target)
    {
        target = _target;
        _isChasing = true;
    }

    private void StopChase()
    {
        Debug.Log("stop chase");
        _isChasing = false;
    }

    public void CheckMovementDirection()
    {
        Vector3 direction = CurrentPosition - PreviousPosition;

        _status.isMoving = direction.magnitude > 0;

        if (_status.isMoving)
        {
            _status.isIdle = false;

            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                _status.isFacingDown = false;
                _status.isFacingUp = false;

                if (direction.x > 0)
                {
                    _status.isFacingLeft = false;
                    _status.isFacingRight = true;

                    if (_isFlipped)
                    {
                        FlipCharacter();
                    }
                }
                else
                {
                    _status.isFacingRight = false;
                    _status.isFacingLeft = true;
                    if (!_isFlipped)
                    {
                        FlipCharacter();
                    }
                }
            }
            else if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
            {
                _status.isFacingLeft = false;
                _status.isFacingRight = false;

                if (direction.y > 0)
                {
                    _status.isFacingDown = false;
                    _status.isFacingUp = true;
                }
                else
                {
                    _status.isFacingUp = false;
                    _status.isFacingDown = true;
                }
            }
        }
        else
        {
            _status.isMoving = false;
            _status.isIdle = true;
        }
    }

    public void FlipCharacter()
    {
        Quaternion newRotation = transform.rotation * Quaternion.Euler(0, 180, 0);
        transform.rotation = newRotation;
        _isFlipped = !_isFlipped;
    }

}
