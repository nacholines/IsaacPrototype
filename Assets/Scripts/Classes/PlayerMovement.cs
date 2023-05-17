using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public KeyCode[] Controls;
    private Vector3 movement;
    public Rigidbody PlayerRigidbody;
    private bool _isFlipped;

    private MovementAnimationStatus _status;
    private MovementAnimationController _controller;

    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
        _controller = GetComponent<MovementAnimationController>();
        _status = new MovementAnimationStatus();
    }

    void Update()
    {
        movement = Vector3.zero;
        _status.isIdle = true;
        _status.isMoving = false;

        if (Input.GetKey(Controls[0]))
        {
            movement += Vector3.up;
            _status.isIdle = false;
            _status.isFacingDown = false;
            _status.isFacingRight = false;
            _status.isFacingLeft = false;
            _status.isFacingUp = true;
            _status.isMoving = true;
        }
        else if (Input.GetKey(Controls[1]))
        {
            movement += Vector3.down;
            _status.isIdle = false;
            _status.isFacingUp = false;
            _status.isFacingRight = false;
            _status.isFacingLeft = false;
            _status.isFacingDown = true;
            _status.isMoving = true;
        }

        if (Input.GetKey(Controls[2]))
        {
            movement += Vector3.left;
            _status.isIdle = false;
            _status.isFacingUp = false;
            _status.isFacingDown = false;
            _status.isFacingRight = false;
            _status.isFacingLeft = true;
            _status.isMoving = true;
            if (!_isFlipped)
            {
                FlipCharacter();
            }
        }
        else if (Input.GetKey(Controls[3]))
        {
            movement += Vector3.right;
            _status.isIdle = false;
            _status.isFacingUp = false;
            _status.isFacingDown = false;
            _status.isFacingLeft = false;
            _status.isFacingRight = true;
            _status.isMoving = true;
            if (_isFlipped)
            {
                FlipCharacter();
            }
        }

        transform.position += movement * Time.deltaTime * movementSpeed;
    }

    private void LateUpdate()
    {
        _controller.SendAnimationStatus(_status);
    }

    private void FlipCharacter()
    {
        Quaternion newRotation = transform.rotation * Quaternion.Euler(0, 180, 0);
        transform.rotation = newRotation;
        _isFlipped = !_isFlipped;
    }

}
