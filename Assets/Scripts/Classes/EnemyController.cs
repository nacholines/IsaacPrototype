using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable, IHealth
{
    public float Health;
    public float DamageDealt;

    private void Update()
    {
        if(Health <= 0)
        {
            Die();
        }
    }

    public void OnTriggerEnter2D (Collider2D other)
    {
        var damageable = other.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Debug.Log(damageable.GetDamage());
            ReduceHealth(damageable.GetDamage());
        }
    }

    public float GetDamage()
    {
        return DamageDealt;
    }

    public void ReduceHealth(float healthPoints)
    {
        Health -= healthPoints;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
