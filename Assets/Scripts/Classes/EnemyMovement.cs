using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Within_range;
    public float Speed = 4.5f;
    private Transform target;
    public bool _isChasing;

    void Awake()
    {
        GameManager.StartEnemyChase += StartChase;
        GameManager.StopEnemyChase += StopChase;
    }

    private void Update()
    {
        if (!_isChasing)
        {
            Speed = 0;
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Speed);
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
}
