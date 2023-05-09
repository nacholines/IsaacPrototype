using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IHealth
{
    public Rigidbody2D PlayerRigidbody2D;
    public float Health;
    private bool _invincible = false;

    private void Update()
    {
        if(Health <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var damageable = other.gameObject.GetComponent<IDamageable>();
        if(damageable != null)
        {
            if(!_invincible)
                ReduceHealth(damageable.GetDamage());
        }
    }

    private void resetInvincibility()
    {
        _invincible = false;
    }

    public void ReduceHealth(float healthPoints)
    {
        _invincible = true;
        Health -= healthPoints;
        Invoke("resetInvincibility", 2);
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
