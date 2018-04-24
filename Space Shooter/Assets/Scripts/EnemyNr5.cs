using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNr5 : MonoBehaviour {

    private float lifePoints;

    public float speed = 10f;

    public int points = 10;

    private float timer = 0;
    private float timerMax = 0;

    public AudioClip pop;

    public GameObject boomAnimation;

    void Start()
    {
        lifePoints = 5f * GameMenager.multiplier;
    }

    void FixedUpdate()
    {

        this.gameObject.GetComponent<Rigidbody2D>().velocity = -1 * this.gameObject.transform.up * speed;
       

        if (lifePoints <= 0)
        {

            AudioSource.PlayClipAtPoint(pop, new Vector3(0, 0, -10), 10);
            Destroy(this.gameObject);
            Points.points += points;
            Instantiate(boomAnimation, transform.position, Quaternion.identity);


        }

        if (Waited(8))
        {
            Destroy(this.gameObject);
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
