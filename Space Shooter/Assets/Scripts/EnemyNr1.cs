using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNr1 : MonoBehaviour {

	private Vector2 enemyShipPosition;
    private Quaternion rotate;

    public GameObject shootPoint;
    public GameObject bulletPrefab;
    public float bulletSpawnDelay;
    public float bulletSpeed = 10f;
    public float bulletBufor = 2f;

    private float lifePoints;

    public float time = 1f;

    public int points = 10;

    public AudioClip pop;

    public GameObject boomAnimation;

	void Start () {

		enemyShipPosition = transform.position;
        bulletSpawnDelay = bulletBufor;
        lifePoints = 5f * GameMenager.multiplier;

    }
	
	void FixedUpdate () {

        time -= Time.deltaTime;
        
        if (time > 0)
        {
            if (enemyShipPosition.x < 0)
            {

                enemyShipPosition.x += 0.06f;
                enemyShipPosition.y = 0.1f * (Mathf.Pow((enemyShipPosition.x + 3), 2)) + 2;

                transform.position = enemyShipPosition;

            }
            else
            {

                enemyShipPosition.x -= 0.06f;
                enemyShipPosition.y = 0.1f * (Mathf.Pow((enemyShipPosition.x - 3), 2)) + 2;

                transform.position = enemyShipPosition;

            }
        }else if (time < -3)
        {
            if (enemyShipPosition.x < 0)
            {

                enemyShipPosition.x -= 0.06f;
                enemyShipPosition.y = 0.1f * (Mathf.Pow((enemyShipPosition.x + 3), 2)) + 2;

                transform.position = enemyShipPosition;
            }
            else
            {

                enemyShipPosition.x += 0.06f;
                enemyShipPosition.y = 0.1f * (Mathf.Pow((enemyShipPosition.x - 3), 2)) + 2;

                transform.position = enemyShipPosition;

            }

        }

        if(time < -6)
        {
            Destroy(this.gameObject);
        }
            


        if (lifePoints <= 0)
        {
            AudioSource.PlayClipAtPoint(pop, new Vector3(0,0,-10), 10);
            Destroy(this.gameObject);
            Points.points += points;
            Instantiate(boomAnimation, transform.position, Quaternion.identity);

        }

        Shoot();
	}

    void OnCollisionEnter2D(Collision2D obj)
    {

        if(obj.gameObject.tag == "PlayerBullet")
        {

            lifePoints -= Shooting.damagePoints;
            Destroy(obj.gameObject);
            StartCoroutine("OnHit");

        }

    }

    void Shoot()
    {

        bulletSpawnDelay -= Time.deltaTime;

        if(bulletSpawnDelay <= 0)
        {

            var bullet = (GameObject)Instantiate(
                bulletPrefab,
                shootPoint.transform.position, Quaternion.identity);


            bullet.GetComponent<Rigidbody2D>().velocity = -1 * bullet.transform.up * bulletSpeed;

            bulletSpawnDelay = bulletBufor;

            Destroy(bullet, 1.5f);

        }

    }

    IEnumerator OnHit()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.4f);
        yield return new WaitForSeconds(0.3f);
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

}
