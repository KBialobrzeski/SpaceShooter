using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNr2 : MonoBehaviour {

    public GameObject shootPoint1;
    public GameObject shootPoint2;
    public GameObject bulletPrefab;
    public float bulletSpawnDelay;
    public float bulletSpeed = 10f;
    public float bulletBufor = 2f;

    static public float stopPoint = 1;

    private float lifePoints;

    public float speed = 10f;

    public float time = 2f;

    public int points = 10;

    public AudioClip pop;

    public GameObject boomAnimation;

    void Start () {

        bulletSpawnDelay = bulletBufor;
        lifePoints = 7f * GameMenager.multiplier;

    }
	
	void FixedUpdate () {

        time -= Time.deltaTime;

        if(time > 0)
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = -1 * this.gameObject.transform.up * speed;
        }
        else if(time < 0 && time > -5)
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = -1 * this.gameObject.transform.up * 0;
        }else if(time < -5 && time > -6f)
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = this.gameObject.transform.up * 3;
        }else if(time < -6f && time > -7.5f)
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = -1 * this.gameObject.transform.up * 15;
        }else if(time < -7.5f)
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

        bulletSpawnDelay -= Time.deltaTime;

        if(bulletSpawnDelay <= 0)
        {

            var bullet1 = (GameObject)Instantiate(bulletPrefab, shootPoint1.transform.position, Quaternion.identity);
            var bullet2 = (GameObject)Instantiate(bulletPrefab, shootPoint2.transform.position, Quaternion.identity);

            bullet1.GetComponent<Rigidbody2D>().velocity = -1 * bullet1.transform.up * bulletSpeed;
            bullet2.GetComponent<Rigidbody2D>().velocity = -1 * bullet2.transform.up * bulletSpeed;

            bulletSpawnDelay = bulletBufor;

            Destroy(bullet1, 1.5f);
            Destroy(bullet2, 1.5f);

        }

    }

    IEnumerator OnHit()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.4f);
        yield return new WaitForSeconds(0.3f);
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

}
