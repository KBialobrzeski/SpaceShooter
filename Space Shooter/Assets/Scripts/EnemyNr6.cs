using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNr6 : MonoBehaviour {

    private float lifePoints;

    public float speed = 5f;

    private float timer = 0;
    private float timerMax = 0;

    public int points = 10;

    public AudioClip pop;

    public GameObject boomAnimation;

    void Start () {
        lifePoints = 5f * GameMenager.multiplier;
    }
	
	void FixedUpdate () {

        if (!Waited(7))
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                Vector3 difference = GameObject.FindGameObjectWithTag("Player").transform.position - this.gameObject.transform.position;
                float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + 90);

                this.gameObject.transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, speed * Time.deltaTime);
            }else if (GameObject.FindGameObjectWithTag("Rambo"))
            {
                Vector3 difference = GameObject.FindGameObjectWithTag("Rambo").transform.position - this.gameObject.transform.position;
                float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                this.gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + 90);

                this.gameObject.transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Rambo").transform.position, speed * Time.deltaTime);
            }
           
        }else 
        {
            this.gameObject.transform.position += -1 * transform.up * speed * Time.deltaTime;
        }

        if (Waited(12))
        {
            Destroy(gameObject);
        }

        if(lifePoints <= 0)
        {
            AudioSource.PlayClipAtPoint(pop, new Vector3(0, 0, -10), 10);
            Destroy(gameObject);
            Points.points += points;
            Instantiate(boomAnimation, transform.position, Quaternion.identity);

        }


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

    IEnumerator OnHit()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.4f);
        yield return new WaitForSeconds(0.3f);
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
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
}
