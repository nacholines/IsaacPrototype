using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public KeyCode[] Controls;
    private Vector3 movement;
    public Rigidbody2D PlayerRigidbody2D;

    void Start()
    {
        PlayerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = Vector3.zero;

        if (Input.GetKey(Controls[0]))
        {
            movement += Vector3.up;
        }else if (Input.GetKey(Controls[1]))
        {
            movement += Vector3.down;
        }

        if (Input.GetKey(Controls[2]))
        {
            movement += Vector3.left;
        }
        else if (Input.GetKey(Controls[3]))
        {
            movement += Vector3.right;
        }

        transform.position += movement * Time.deltaTime * movementSpeed;
    }

}
