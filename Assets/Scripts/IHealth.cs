using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    void ReduceHealth(float healthPoints);
    void Die();
}
