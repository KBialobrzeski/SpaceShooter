using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingDamage : MonoBehaviour {

    private float lifePoints;

    public int points = 50;

    public AudioClip pop;

    public GameObject boomAnimation;
	
    void Start()
    {
        lifePoints = 75f * GameMenager.multiplier;
    }

	void FixedUpdate () {

        if (lifePoints <= 0)
        {
            AudioSource.PlayClipAtPoint(pop, new Vector3(0, 0, -10), 10);
            Destroy(this.gameObject);
            BossNr1.gunPoints--;
            Points.points += points;
            Instantiate(boomAnimation, new Vector3(transform.position.x, transform.position.y, -0.1f), Quaternion.identity);

            if(this.gameObject.name == "RocketPointNr1")
            {
                BossNr1.r1 = 1;
            }

            if (this.gameObject.name == "RocketPointNr2")
            {
                BossNr1.r2 = 1;
            }

            if (this.gameObject.name == "GunPointNr1")
            {
                BossNr1.g1 = 1;
            }

            if (this.gameObject.name == "GunPointNr2")
            {
                BossNr1.g2 = 1;
            }
        }

    }

    void OnCollisionEnter2D(Collision2D obj)
    {

        if (obj.gameObject.tag == "PlayerBullet")
        {

            lifePoints -= Shooting.damagePoints;
            Destroy(obj.gameObject);
            GameObject boomShoot = (GameObject)Instantiate(boomAnimation, new Vector3(transform.position.x, transform.position.y, -0.1f), Quaternion.identity);
            boomShoot.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        }

    }

}
