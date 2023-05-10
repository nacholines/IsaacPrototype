using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform ShootingPosition;
    public Transform ShootingStart;
    public KeyCode[] Controls;
    public GameObject BulletPrefab;
    private bool _allowFire = true;
    public float FireRate;
    public enum ShootingDirection
    {
        Up, 
        Down, 
        Left, 
        Right
    }

    void Update()
    {
        if (_allowFire)
        {
            if (Input.GetKey(Controls[0]))
            {
                ShootingStart.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                StartCoroutine(firingRate());
            }
            if (Input.GetKey(Controls[1]))
            {
                ShootingStart.transform.rotation = Quaternion.Euler(0f, 0f, 270f);
                StartCoroutine(firingRate());
            }
            if (Input.GetKey(Controls[2]))
            {
                ShootingStart.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                StartCoroutine(firingRate());
            }
            if (Input.GetKey(Controls[3]))
            {
                ShootingStart.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                StartCoroutine(firingRate());
            }
        }
    }

    private IEnumerator firingRate()
    {
        _allowFire = false;
        shoot();
        yield return new WaitForSeconds(FireRate);
        _allowFire = true;
    }

    private void shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, ShootingStart.position, ShootingStart.rotation);
    }
}
