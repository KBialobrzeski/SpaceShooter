using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting2 : MonoBehaviour
{


    public float bulletSpawnDelay;
    public float buffor = 0.08f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;

    static public float damagePoints = 1f;

    void Start()
    {

        bulletSpawnDelay = buffor;

    }

    void FixedUpdate()
    {

        Fire();

    }

    public void Fire()
    {

        bulletSpawnDelay -= Time.deltaTime;

        if (bulletSpawnDelay <= 0)
        {

            var bullet = (GameObject)Instantiate(bulletPrefab, this.gameObject.transform.position, Quaternion.identity);

            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed;

            bulletSpawnDelay = buffor;

            Destroy(bullet, 1.5f);

        }
    }
}
