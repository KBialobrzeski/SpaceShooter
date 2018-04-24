using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMenu : MonoBehaviour
{

    public float bulletSpawnDelay;
    public float buffor = 7f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;

    public int bulletRevert = 1;

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

            bullet.transform.rotation = Quaternion.Euler(0, 0, -45);

            bullet.GetComponent<Rigidbody2D>().velocity = bulletRevert * bullet.transform.up * bulletSpeed;

            bulletSpawnDelay = buffor;

            Destroy(bullet, 5f);

        }
    }

}
