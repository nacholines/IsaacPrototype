using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Within_range;
    public float Speed = 4.5f;
    [SerializeField] GameManager gameManager;

    void Start()
    {
        gameManager.StartEnemyChase += StartChase;
        gameManager.StopEnemyChase += StopChase;
    }

    private void StartChase(Transform target)
    {
        Debug.Log(transform.position);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Speed);
        Debug.Log(transform.position);
    }

    private void StopChase()
    {
        Debug.Log("stopchase");
        Speed = 0;
    }
}
