using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDamageable
{
    public float Speed;
    public Rigidbody2D Rb;
    public float Range;
    private float _damage = 5f;

    public float GetDamage()
    {
        return _damage;
    }

    public void TakeDamage()
    {
        Destroy(this.gameObject);
    }

    void Start()
    {
        Rb.velocity = transform.right * Speed;
        Destroy(this.gameObject, Range);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        TakeDamage();
    }
}
