using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNr1 : MonoBehaviour {

    public float speed = 2f;

    public static float lifePoints;

    public GameObject gunPoint1;
    public GameObject gunPoint2;
    public GameObject gunPrefab;

    public float gunSpawnDelay = 2.7f;
    public float gunSpeed = 10f;
    public float gunBufor = 0.1f;
    public int gunPause = 0;

    public GameObject rocketPoint1;
    public GameObject rocketPoint2;
    public GameObject rocketPrefab;

    public float rocketSpawnDelay = 2.7f;
    private float rocketSpeed = 5f;

    public GameObject laserPoint;
    public GameObject laserPrefab;

    public float laserSpawnDelay = 4f;
    public float laserBufor = 4f;
    private bool isCreated;
    public GameObject laserBeam;

    public float sunSpawnDelay = 0.5f;
    public float sunBuffor = 0.5f;
    public float sunShootSpeed = 1f;
    public GameObject sunPoint;
    public GameObject sunPrefab;
    public Vector3 sunShootPosition = new Vector3(0,5,0);

    private int counter;

    private float timer = 0;
    private float timerMax = 0;

    public static int gunPoints;

    public int points = 200;

    private bool doPoints;

    public AudioClip boom;
    private AudioSource audioo;

    public GameObject gunBonus;

    public GameObject boomAnimation;

    private GameObject boomAni;

    public GameObject smokeAnimation;

    public GameObject Rocket1Smoke;
    public GameObject Rocket2Smoke;
    public GameObject Gun1Smoke;
    public GameObject Gun2Smoke;

    private GameObject R1ani;
    private GameObject R2ani;
    private GameObject G1ani;
    private GameObject G2ani;

    public static int r1, r2, g1, g2;

    void Start () {

        this.GetComponent<PolygonCollider2D>().enabled = false;
        counter = 0;
        gunPoints = 4;
        doPoints = true;
        lifePoints = 600 * GameMenager.multiplier;
        audioo = gameObject.GetComponent<AudioSource>();

        r1 = 0;
        r2 = 0;
        g1 = 0;
        g2 = 0;

    }
	
	void FixedUpdate () {

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
                    if (Waited(2))
                    {
                        counter++;
                        timer = 0;
                    }
                        break;
                }
            case 2:
                {
                    this.gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(-5, 2.6f, 0), speed * Time.deltaTime);
                    this.gameObject.transform.localRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 10), 0.1f);

                    if (this.gameObject.transform.position.x == -5)
                    {
                        counter++;
                    }
                    break;
                }
            case 3:
                {
                    this.gameObject.transform.localRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), 0.7f);

                    if (Waited(2))
                    {
                        counter++;
                        timer = 0;
                    }
                    break;
                }
            case 4:
                {
                    this.gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(-5, 3.5f, 0), 0.3f * speed * Time.deltaTime);
                    if(this.gameObject.transform.position.y == 3.5f)
                    {
                        counter++;
                    }
                    break;
                }
            case 5:
                {
                    this.gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(-5, -5, 0), 5 * speed * Time.deltaTime);
                    if (this.gameObject.transform.position.y == -5)
                    {
                        counter++;
                    }
                    break;
                }
            case 6:
                {
                    this.gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(-5, 2.6f, 0), speed * Time.deltaTime);
                    if (this.gameObject.transform.position.y == 2.6f)
                    {
                        counter++;
                    }
                    break;
                }
            case 7:
                {
                    if (Waited(2))
                    {
                        counter++;
                        timer = 0;
                    }
                    break;
                }
            case 8:
                {
                    this.gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(5, 2.6f, 0), speed * Time.deltaTime);

                    this.gameObject.transform.localRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, -10), 0.1f);

                    if (this.gameObject.transform.position.x == 5)
                    {
                        counter++;
                    }
                    break;
                }
            case 9:
                {
                    this.gameObject.transform.localRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), 0.7f);

                    if (Waited(2))
                    {
                        counter++;
                        timer = 0;
                    }
                    break;
                }
            case 10:
                {
                    this.gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(5, 3.5f, 0), 0.3f * speed * Time.deltaTime);
                    if (this.gameObject.transform.position.y == 3.5f)
                    {
                        counter++;
                    }
                    break;
                }
            case 11:
                {
                    this.gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(5, -5, 0), 5 * speed * Time.deltaTime);
                    if (this.gameObject.transform.position.y == -5)
                    {
                        counter++;
                    }
                    break;
                }
            case 12:
                {
                    this.gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(5, 2.6f, 0), speed * Time.deltaTime);
                    if (this.gameObject.transform.position.y == 2.6f)
                    {
                        counter++;
                    }
                    break;
                }
            case 13:
                {
                    if (Waited(2))
                    {
                        counter++;
                        timer = 0;
                    }
                    break;
                }
            case 14:
                {
                    this.gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), speed * Time.deltaTime);
                    if(this.gameObject.transform.position.x == 0 && this.gameObject.transform.position.y == 0)
                    {
                        counter++;
                    }
                    break;
                }
            case 15:
                {
                    Laser();
                    if(Waited(4.1f) && !isCreated)
                    {
                        counter++;
                        timer = 0;
                    }
                    break;
                }
            case 16:
                {
                    if (Waited(1))
                    {
                        counter = 0;
                        timer = 0;
                    }
                    break;
                }
            case 17:
                {
                    this.gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 2.6f, 0), speed * Time.deltaTime);
                    this.gameObject.transform.localRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), 0.7f);
                    this.GetComponent<PolygonCollider2D>().enabled = true;

                    if(isCreated == true)
                    {
                        Destroy(laserBeam);
                        isCreated = false;
                    }

                    SunGunShoot();
                    break;
                }
            case 18:
                {
                    break;
                }

        }

        if (r1 == 1)
        {
            R1ani = Instantiate(smokeAnimation, new Vector3(Rocket1Smoke.transform.position.x, Rocket1Smoke.transform.position.y, -0.1f), Quaternion.identity);
            R1ani.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            r1 = 0;
        }

        if (R1ani)
        {
            R1ani.transform.position = new Vector3(Rocket1Smoke.transform.position.x, Rocket1Smoke.transform.position.y, -0.1f);
        }

        if (r2 == 1)
        {
            R2ani = Instantiate(smokeAnimation, new Vector3(Rocket2Smoke.transform.position.x, Rocket2Smoke.transform.position.y, -0.1f), Quaternion.identity);
            R2ani.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            r2 = 0;
        }

        if (R2ani)
        {
            R2ani.transform.position = new Vector3(Rocket2Smoke.transform.position.x, Rocket2Smoke.transform.position.y, -0.1f);
        }

        if (g1 == 1)
        {
            G1ani = Instantiate(smokeAnimation, new Vector3(Gun1Smoke.transform.position.x, Gun1Smoke.transform.position.y, -0.1f), Quaternion.identity);
            G1ani.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            g1 = 0;
        }

        if (G1ani)
        {
            G1ani.transform.position = new Vector3(Gun1Smoke.transform.position.x, Gun1Smoke.transform.position.y, -0.1f);
        }

        if (g2 == 1)
        {
            G2ani = Instantiate(smokeAnimation, new Vector3(Gun2Smoke.transform.position.x, Gun2Smoke.transform.position.y, -0.1f), Quaternion.identity);
            G2ani.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            g2 = 0;
        }

        if (G2ani)
        {
            G2ani.transform.position = new Vector3(Gun2Smoke.transform.position.x, Gun2Smoke.transform.position.y, -0.1f);
        }

        if (gunPoints == 0)
        {
            counter = 17;
        }

        if(lifePoints <= 0)
        {
            
            counter = 18;
            Destroy(this.gameObject, 3f);
            Destroy(R1ani, 3f);
            Destroy(R2ani, 3f);
            Destroy(G1ani, 3f);
            Destroy(G2ani, 3f);
            if (doPoints)
            {
                Points.points += points;
                doPoints = false;
                audioo.PlayOneShot(boom);

                var bonus = (GameObject)Instantiate(gunBonus, this.gameObject.transform.position, Quaternion.identity);
                Destroy(bonus, 10);

                GameMenager.multiplier += 0.5f;
                Destroy(GameObject.Find("Ram(Clone)"));
                
            }
            if (!boomAni)
            {
                boomAni = (GameObject)Instantiate(boomAnimation, new Vector3(transform.position.x, transform.position.y, this.gameObject.transform.position.z - 1), Quaternion.identity);
                boomAni.transform.localScale = new Vector3(5f, 5f, 5f);
            }
            
        }

        GunShoot();
        RocketShoot();
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

    void Laser()
    {
        laserSpawnDelay -= Time.deltaTime;

        if (!isCreated && laserSpawnDelay <= 0)
        {
            laserBeam = (GameObject)Instantiate(laserPrefab,laserPoint.transform.position, Quaternion.identity);
            isCreated = true;
        }
        if (isCreated && laserSpawnDelay >= -4)
        {
            laserBeam.transform.localScale += new Vector3(0.0001F, 0.02F);
        }
        else if(isCreated && laserSpawnDelay >= -17.5f && laserSpawnDelay < -4)
        {
            laserBeam.transform.Rotate(0, 0, -40 * Time.deltaTime);
        }
        else if(isCreated && laserSpawnDelay >= -21.5f && laserSpawnDelay < -17.5f)
        {
            laserBeam.transform.localScale += new Vector3(-0.0001F, -0.02F);
        }
        else if(isCreated && laserSpawnDelay < -21.5f)
        {
            Destroy(laserBeam);
            isCreated = false;
            laserSpawnDelay = 4;
        }
        
    }

    void GunShoot()
    {

        gunSpawnDelay -= Time.deltaTime;

        if (gunSpawnDelay <= 0)
        {
            if (gunPoint1)
            {
                var bullet1 = (GameObject)Instantiate(gunPrefab, gunPoint1.transform.position, Quaternion.identity);
                bullet1.GetComponent<Rigidbody2D>().velocity = -1 * bullet1.transform.up * gunSpeed;
                Destroy(bullet1, 1.5f);
            }
            if (gunPoint2)
            {
                var bullet2 = (GameObject)Instantiate(gunPrefab, gunPoint2.transform.position, Quaternion.identity);
                bullet2.GetComponent<Rigidbody2D>().velocity = -1 * bullet2.transform.up * gunSpeed;
                Destroy(bullet2, 1.5f);
            }

            gunSpawnDelay = gunBufor;

            gunPause++;

            if(gunPause % 10 == 0)
            {
                gunSpawnDelay = 2f;
            }

        }

    }

    void RocketShoot()
    {
        rocketSpawnDelay -= Time.deltaTime;

        if (rocketSpawnDelay <= 0)
        {
            if (rocketPoint1)
            {
                var rocket1 = Instantiate(rocketPrefab, rocketPoint1.transform.position, Quaternion.identity);
                rocket1.GetComponent<Rigidbody2D>().velocity = (GameObject.Find("Player(Clone)").transform.position - rocket1.transform.position).normalized * rocketSpeed;
                Destroy(rocket1, 5f);
            }

            if (rocketPoint2)
            {
                var rocket2 = Instantiate(rocketPrefab, rocketPoint2.transform.position, Quaternion.identity);
                rocket2.GetComponent<Rigidbody2D>().velocity = (GameObject.Find("Player(Clone)").transform.position - rocket2.transform.position).normalized * rocketSpeed;               
                Destroy(rocket2, 5f);
            }

            rocketSpawnDelay = 2f;

        }
    }

    void SunGunShoot()
    {
        sunSpawnDelay -= Time.deltaTime;

        if(sunSpawnDelay <= 0)
        {
            sunShootPosition = Random.insideUnitCircle * 10;

            while (sunShootPosition.y >= 4.5f)
            {
                sunShootPosition = Random.insideUnitCircle * 10;
            }

            var sun = Instantiate(sunPrefab, sunPoint.transform.position, Quaternion.identity);
            sun.GetComponent<Rigidbody2D>().velocity = (sunShootPosition - sun.transform.position).normalized * sunShootSpeed;
            sunSpawnDelay = sunBuffor;
            Destroy(sun, 2f);
        }

        

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
