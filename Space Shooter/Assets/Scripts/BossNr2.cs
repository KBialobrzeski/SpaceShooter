using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossNr2 : MonoBehaviour {

    public Image hpBar;
    public Image hpBar_BG;
    float maxHealth;

    public float shootDelay = 1;
    public static float bufor;
    public GameObject bulletPrefab;
    public GameObject shootPoint;
    public float bulletSpeed = 1f;
    public float speed = 2f;

    public Vector3 pos;
    private int posCount = 0;

    private int counter;

    private float timer = 0;
    private float timerMax = 0;

    public float lifePoints;

    public int points = 100;

    private bool doPoints;

    public AudioClip boom;
    private AudioSource audioo;

    public GameObject gunBonus;

    public GameObject boomAnimation;

    private GameObject boomAni;

    void Start () {
        lifePoints = 270f * GameMenager.multiplier;
        maxHealth = lifePoints;
        counter = 0;
        doPoints = true;

        bufor = shootDelay;

        audioo = gameObject.GetComponent<AudioSource>();

        if (GameObject.FindGameObjectsWithTag("Boss").Length > 1)
        {
            this.hpBar_BG.transform.position = new Vector2(hpBar_BG.transform.position.x, hpBar_BG.transform.position.y - 25);
        }
    }
	
	void FixedUpdate () {

        

        hpBar.fillAmount = lifePoints / maxHealth;

        Vector3 difference = GameObject.Find("Player(Clone)").transform.position - this.gameObject.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        switch (counter)
        {
            case 0:
                {
                    this.gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 2.6f, 0), speed * Time.deltaTime);

                    if (this.gameObject.transform.position.y == 2.6f)
                    {
                        counter++;
                    }
                    break;
                }
            case 1:
                {
                    this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + 90);

                    if (Waited(3))
                    {
                        counter++;
                        timer = 0;
                    }
                    Shoot();
                    break;
                }
            case 2:
                {
                    this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + 90);

                    if (posCount == 0)
                    {
                        if(this.gameObject.name == "FirstBoss2")
                        {
                            pos = GameObject.Find("Player(Clone)").transform.position;
                        }
                        else
                        {
                            if (GameObject.Find("FirstBoss2"))
                            {
                                pos = GameObject.Find("FirstBoss2").transform.position;
                            }
                            else
                            {
                                pos = GameObject.Find("Player(Clone)").transform.position;
                            }
                        }
                        posCount = 1;
                    }
                    
                    this.gameObject.transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
                    if (this.gameObject.transform.position == pos)
                    {
                        counter = 1;
                        posCount = 0;
                    }
                    Shoot();
                    break;
                }
            case 3:
                {
                    break;
                }
        }

        if (lifePoints <= 0)
        {
            counter = 3;
            Destroy(this.gameObject, 3f);

            if (doPoints)
            {
                audioo.PlayOneShot(boom);
                Points.points += points;
                doPoints = false;

                PlayerShipManager.boss2Up++;

                BossNr2.bufor = 0.5f;

                if (PlayerShipManager.boss2Up % 2 == 0)
                {
                    var bonus = (GameObject)Instantiate(gunBonus, this.gameObject.transform.position, Quaternion.identity);
                    Destroy(bonus, 10);
                    GameMenager.multiplier += 0.5f;
                }
            }
            if (!boomAni)
            {
                boomAni = (GameObject)Instantiate(boomAnimation, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z - 1), Quaternion.identity);
                boomAni.transform.localScale = new Vector3(4f, 4f, 4f);
            }

        }

	}

    void Shoot()
    {
        shootDelay -= Time.deltaTime;

        if (shootDelay <= 0)
        {

            var bullet = Instantiate(bulletPrefab, shootPoint.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = (GameObject.Find("Player(Clone)").transform.position - bullet.transform.position).normalized * bulletSpeed;

            Vector3 difference = GameObject.Find("Player(Clone)").transform.position - this.gameObject.transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + 90);

            Destroy(bullet, 5f);
            shootDelay = bufor;

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

    void OnCollisionEnter2D(Collision2D obj)
    {

        if (obj.gameObject.tag == "PlayerBullet")
        {

            lifePoints -= Shooting.damagePoints;
            Destroy(obj.gameObject);

        }

    }
}
