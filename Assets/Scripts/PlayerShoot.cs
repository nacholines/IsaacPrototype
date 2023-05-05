using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform PlayerPosition;
    public Transform ShootingStart;
    public KeyCode[] Controls;
    public GameObject BulletPrefab;
    public float BulletSpeed;
    public enum ShootingDirection
    {
        Up, 
        Down, 
        Left, 
        Right
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(Controls[0]))
        {
            PlayerPosition.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            StartCoroutine(shoot());
        }
        if (Input.GetKey(Controls[1]))
        {
            PlayerPosition.transform.rotation = Quaternion.Euler(0f, 0f, 270f);
            StartCoroutine(shoot());
        }
        if (Input.GetKey(Controls[2]))
        {
            PlayerPosition.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            StartCoroutine(shoot());
        }
        if (Input.GetKey(Controls[3]))
        {
            PlayerPosition.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            StartCoroutine(shoot());
        }
    }

    private IEnumerator shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, ShootingStart.position, ShootingStart.rotation);

        yield return new WaitForSeconds(0.5f);
    }
}
