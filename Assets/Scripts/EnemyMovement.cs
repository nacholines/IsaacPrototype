using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform Target;
    public float Within_range;
    public float Speed = 4.5f;
    private bool _isChasing = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(Target.position, transform.position);
        if (dist <= Within_range)
        {
            _isChasing = true;
        }

        if (_isChasing)
        {
            StartChase(); 
        }
    }

    private void StartChase()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Speed);
    }
}
