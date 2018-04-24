using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawn : MonoBehaviour {

    private float rndx;

    private int rndBonus;

    public GameObject hpBonus;
    public GameObject gunBonus;
    public GameObject shieldBonus;

    private float timer = 0;
    private float timerMax = 0;

    private float speed = 4;

    void Update()
    {
        if (Waited(20))
        {
            rndx = Random.Range(-7, 8);
            rndBonus = Random.Range(1, 3);

            switch (rndBonus)
            {
                case 1:
                    {
                        var bonus = (GameObject)Instantiate(hpBonus, new Vector2(rndx, 7), Quaternion.identity);
                        bonus.GetComponent<Rigidbody2D>().velocity = -1 * bonus.transform.up * speed;
                        Destroy(bonus, 10);
                        break;
                    }
                case 2:
                    {
                        var bonus = (GameObject)Instantiate(shieldBonus, new Vector2(rndx, 7), Quaternion.identity);
                        bonus.GetComponent<Rigidbody2D>().velocity = -1 * bonus.transform.up * speed;
                        Destroy(bonus, 10);
                        break;
                    }
            }

            timer = 0;
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
}
