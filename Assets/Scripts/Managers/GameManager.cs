using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform Player;

    void Start()
    {
        StartEnemyChase?.Invoke(Player);
    }

    void Update()
    {
        if (!Player)
        {
            StopEnemyChase?.Invoke();
        }
    }

    private void OnDestroy()
    {
        StartEnemyChase = null;
        StopEnemyChase = null;
    }

    public static Action<Transform> StartEnemyChase;
    public static Action StopEnemyChase;
}
