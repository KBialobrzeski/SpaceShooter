using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipManager : MonoBehaviour {

    static public int healthPoints;

    public GameObject addShootPoint1;
    public GameObject addShootPoint2;
    public GameObject addShootPoint3;
    public GameObject addShootPoint4;

    public GameObject shieldLight;

    public AudioClip boom;
    private AudioSource audioo;

    private float timer = 0;
    private float timerMax = 0;

    private int shootPoints;

    public static int boss2Up;

    public GameObject boomAnimation;

    public GameObject boomAni;

    void Start () {

        healthPoints = 10;
        Time.timeScale = 1;
        shootPoints = 0;
        addShootPoint1.SetActive(false);
        addShootPoint2.SetActive(false);
        addShootPoint3.SetActive(false);
        addShootPoint4.SetActive(false);

        audioo = gameObject.GetComponent<AudioSource>();

        boss2Up = 0;

}
	
	void FixedUpdate () {
		
        if(healthPoints <= 0)
        {
            Time.timeScale = 0.5f;

            if (!boomAni)
            {
                boomAni = Instantiate(boomAnimation, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -0.1f), Quaternion.identity);
                audioo.PlayOneShot(boom, 1);
            }

            if (Waited(2))
            {
                Destroy(this.gameObject);
                Time.timeScale = 0;
                timer = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {

            healthPoints = 10;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {

            healthPoints = 1;
        }

    }

    void OnCollisionEnter2D (Collision2D obj)
    {

        if (obj.gameObject.tag == "EnemyBullet" && this.gameObject.tag == "Player")
        {

            healthPoints -= 1;
            Destroy(obj.gameObject);
            StartCoroutine("OnHit");

        }
        else if (obj.gameObject.tag == "Enemy" && this.gameObject.tag == "Player")
        {
            healthPoints -= 1;
            Destroy(obj.gameObject);
            Instantiate(boomAnimation, new Vector3(obj.gameObject.transform.position.x, obj.gameObject.transform.position.y, -0.1f), Quaternion.identity);
            StartCoroutine("OnHit");
        }
        else if ((obj.gameObject.tag == "BossLaser" || obj.gameObject.tag =="Boss") && this.gameObject.tag == "Player")
        {

            healthPoints -= 1;
            StartCoroutine("OnHit");

        }
        else if(obj.gameObject.tag == "HP_UP")
        {
            if(healthPoints < 10)
            {
                healthPoints += 1;
                Destroy(obj.gameObject);
            }
        }
        else if(obj.gameObject.tag == "GUN_UP")
        {
            shootPoints++;
            switch (shootPoints)
            {
                case 1:
                    {
                        addShootPoint1.SetActive(true);
                        break;
                    }
                case 2:
                    {
                        addShootPoint2.SetActive(true);
                        break;
                    }
                case 3:
                    {
                        addShootPoint3.SetActive(true);
                        break;
                    }
                case 4:
                    {
                        addShootPoint4.SetActive(true);
                        break;
                    }
            }
            Destroy(obj.gameObject);
        }
        else if(obj.gameObject.tag == "SHIELD_UP")
        {
            StartCoroutine("ShieldUp");
            Destroy(obj.gameObject);
        }
        else
        {
        }
    }

    private bool Waited(float seconds)
    {
        timerMax = seconds;

        timer += Time.deltaTime;

        if (timer >= timerMax)
        {
            return true;
        }

        return false;
    }

    IEnumerator OnHit()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.4f);
        this.gameObject.tag = "Rambo";
        Time.timeScale = 0.7f;
        yield return new WaitForSeconds(2);
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        this.gameObject.tag = "Player";
        Time.timeScale = 1;
    }

    IEnumerator ShieldUp()
    {
        this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        shieldLight.SetActive(true);
        yield return new WaitForSeconds(5);
        this.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        shieldLight.SetActive(!shieldLight.activeInHierarchy);
    }
}
