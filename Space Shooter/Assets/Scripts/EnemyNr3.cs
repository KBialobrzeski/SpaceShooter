using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNr3 : MonoBehaviour {

    private Vector2 enemyShipPosition;

    public GameObject shootPoint;
    public GameObject bulletPrefab;

    private float lifePoints;

    public float destroyTimer = 7.5f;

    public float shootTimer = 2f;

    private float bulletSpeed = 5f;

    public int points = 10;

    public AudioClip pop;

    public GameObject boomAnimation;
    void Start () {

        enemyShipPosition = transform.position;
        lifePoints = 3f * GameMenager.multiplier;

    }
	
	void FixedUpdate () {

        destroyTimer -= Time.deltaTime;

        if(enemyShipPosition.x < 0)
        {

            enemyShipPosition.x += 0.015f;
            enemyShipPosition.y = 3.5f * enemyShipPosition.x + 25;

            transform.position = enemyShipPosition;

        }
        else if(enemyShipPosition.x > 0)
        {

            enemyShipPosition.x -= 0.015f;
            enemyShipPosition.y = -3.5f * enemyShipPosition.x + 25;

            transform.position = enemyShipPosition;

        }

        if (destroyTimer <= 0)
        {

            Destroy(this.gameObject);

        }

        if (lifePoints <= 0)
        {
            AudioSource.PlayClipAtPoint(pop, new Vector3(0, 0, -10), 10);
            Destroy(this.gameObject);
            Points.points += points;
            Instantiate(boomAnimation, transform.position, Quaternion.identity);

        }


        Shoot();

    }

    void OnCollisionEnter2D(Collision2D obj)
    {

        if (obj.gameObject.tag == "PlayerBullet")
        {

            lifePoints -= Shooting.damagePoints;
            Destroy(obj.gameObject);
            StartCoroutine("OnHit");

        }

    }


    void Shoot()
    {

       shootTimer -= Time.deltaTime;

       if(shootTimer <= 0)
       {
            var bullet = Instantiate(bulletPrefab, shootPoint.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = (GameObject.Find("Player(Clone)").transform.position - transform.position).normalized * bulletSpeed;

            shootTimer = 20f;
            Destroy(bullet, 5f);
       }
    }

    IEnumerator OnHit()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.4f);
        yield return new WaitForSeconds(0.3f);
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

}
