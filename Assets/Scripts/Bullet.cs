using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D Rb;
    void Start()
    {
        Rb.velocity = transform.right * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
