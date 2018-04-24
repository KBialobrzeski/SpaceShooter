using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMenager : MonoBehaviour {

    public GameObject enemyShipNr1;
    public GameObject enemyShipNr2;
    public GameObject enemyShipNr3;
    public GameObject enemyShipNr5;
    public GameObject enemyShipNr6;

    public GameObject bossShipNr1;
    public GameObject bossNr1Ram;
    public GameObject bossShipNr2;

    private float wavesTime;

    private int wavesCount = 1;

    public float buffor = 1f;

    private int random;

    private int waveNr = 0;

    private bool isCreated;

    private int boss2Count = 0;

    private int bossSelect = 2;

    void Start()
    {

        wavesTime = 4f;

    }

    void FixedUpdate()
    {

        wavesTime -= Time.deltaTime;
        
        if (wavesTime <= 0)
        {
            while(random == waveNr)
            {
                random = Random.Range(1, 6);
            }
            
            if(wavesCount % 10 == 0)
            {
                if(bossSelect % 2 == 0)
                {
                    random = 6;
                }
                else
                {
                    random = 7;
                }
                
            }

            switch (random)
            {

                case 1:
                    {
                        EnemyNr1Spawn();
                        wavesTime = buffor;
                        waveNr = random;
                        wavesCount++;
                        break;
                    }
                case 2:
                    {
                        EnemyNr2Spawn();
                        wavesTime = buffor;
                        waveNr = random;
                        wavesCount++;
                        break;
                    }
                case 3:
                    {
                        EnemyNr3Spawn();
                        wavesTime = buffor;
                        waveNr = random;
                        wavesCount++;
                        break;
                    }
                case 4:
                    {
                        EnemyNr5Spawn();
                        wavesTime = buffor;
                        waveNr = random;
                        wavesCount++;
                        break;
                    }
                case 5:
                    {
                        EnemyNr6Spawn();
                        wavesTime = buffor;
                        waveNr = random;
                        wavesCount++;
                        break;
                    }
                case 6:
                    {
                        if (!GameObject.Find("BossNr1(Clone)") && !isCreated)
                        {
                            BossNr1Spawn();
                            isCreated = true;
                            wavesTime = 1;
                        }
                        else if(!GameObject.Find("BossNr1(Clone)") && isCreated)
                        {
                            wavesTime = buffor;
                            wavesCount++;
                            isCreated = false;
                            waveNr = random;
                            bossSelect++;
                        }
                        else if (GameObject.Find("BossNr1(Clone)"))
                        {
                            wavesTime = 1;
                        }
                        break;
                    }
                case 7:
                    {

                        if (boss2Count <= 1)
                        {
                            BossNr2Spawn();
                            boss2Count++;
                            wavesTime = 3;
                        }
                        else if (!GameObject.FindGameObjectWithTag("Boss") && boss2Count > 1)
                        {
                            boss2Count = 0;
                            wavesTime = buffor;
                            wavesCount++;
                            waveNr = random;
                            bossSelect++;
                        }
                        break;
                    }

            }
        }
    }

    void EnemyNr1Spawn()
    {
        Instantiate(enemyShipNr1, new Vector2(-9, 7.5f), Quaternion.identity);
        Instantiate(enemyShipNr1, new Vector2(9, 7.5f), Quaternion.identity);
        Instantiate(enemyShipNr1, new Vector2(-10.5f, 9), Quaternion.identity);
        Instantiate(enemyShipNr1, new Vector2(10.5f, 9), Quaternion.identity);
        Instantiate(enemyShipNr1, new Vector2(-12f, 10.5f), Quaternion.identity);
        Instantiate(enemyShipNr1, new Vector2(12f, 10.5f), Quaternion.identity);
        Instantiate(enemyShipNr1, new Vector2(13.5f, 12f), Quaternion.identity);
        Instantiate(enemyShipNr1, new Vector2(-13.5f, 12f), Quaternion.identity);
        Instantiate(enemyShipNr1, new Vector2(-14.8f, 13f), Quaternion.identity);
        Instantiate(enemyShipNr1, new Vector2(14.8f, 13f), Quaternion.identity);
    }

    void EnemyNr2Spawn()
    {
        Instantiate(enemyShipNr2, new Vector2(-6.8f, 7), Quaternion.identity);
        Instantiate(enemyShipNr2, new Vector3(-2.5f, 7), Quaternion.identity);
        Instantiate(enemyShipNr2, new Vector2(6.8f, 7), Quaternion.identity);
        Instantiate(enemyShipNr2, new Vector2(2.5f, 7), Quaternion.identity);
        Instantiate(enemyShipNr2, new Vector2(-4.3f, 9), Quaternion.identity);
        Instantiate(enemyShipNr2, new Vector2(0, 9), Quaternion.identity);
        Instantiate(enemyShipNr2, new Vector2(4.3f, 9), Quaternion.identity);
    }

    void EnemyNr3Spawn()
    {
        Instantiate(enemyShipNr3, new Vector2(-9f, -7f), Quaternion.identity);
        Instantiate(enemyShipNr3, new Vector2(-9.6f, -8.2f), Quaternion.identity);
        Instantiate(enemyShipNr3, new Vector2(-10.2f, -9.4f), Quaternion.identity);
        Instantiate(enemyShipNr3, new Vector2(-10.8f, -10.6f), Quaternion.identity);
        Instantiate(enemyShipNr3, new Vector2(9f, -7f), Quaternion.identity);
        Instantiate(enemyShipNr3, new Vector2(9.6f, -8.2f), Quaternion.identity);
        Instantiate(enemyShipNr3, new Vector2(10.2f, -9.4f), Quaternion.identity);
        Instantiate(enemyShipNr3, new Vector2(10.8f, -10.6f), Quaternion.identity);
    }

    void EnemyNr5Spawn()
    {
        Instantiate(enemyShipNr5, new Vector2(-0.8f, 6f), Quaternion.identity);
        Instantiate(enemyShipNr5, new Vector2(0.8f, 6f), Quaternion.identity);
        Instantiate(enemyShipNr5, new Vector2(-0.8f, 8f), Quaternion.identity);
        Instantiate(enemyShipNr5, new Vector2(0.8f, 8f), Quaternion.identity);
        Instantiate(enemyShipNr5, new Vector2(-0.8f, 10f), Quaternion.identity);
        Instantiate(enemyShipNr5, new Vector2(0.8f, 10f), Quaternion.identity);
        Instantiate(enemyShipNr5, new Vector2(-0.8f, 12f), Quaternion.identity);
        Instantiate(enemyShipNr5, new Vector2(0.8f, 12f), Quaternion.identity);
        Instantiate(enemyShipNr5, new Vector2(-0.8f, 14f), Quaternion.identity);
        Instantiate(enemyShipNr5, new Vector2(0.8f, 14f), Quaternion.identity);
        Instantiate(enemyShipNr5, new Vector2(-0.8f, 16f), Quaternion.identity);
        Instantiate(enemyShipNr5, new Vector2(0.8f, 16f), Quaternion.identity);
        Instantiate(enemyShipNr5, new Vector2(-0.8f, 18f), Quaternion.identity);
        Instantiate(enemyShipNr5, new Vector2(0.8f, 18f), Quaternion.identity);
        Instantiate(enemyShipNr5, new Vector2(-0.8f, 20f), Quaternion.identity);
        Instantiate(enemyShipNr5, new Vector2(0.8f, 20f), Quaternion.identity);
        Instantiate(enemyShipNr5, new Vector2(-0.8f, 22f), Quaternion.identity);
        Instantiate(enemyShipNr5, new Vector2(0.8f, 22f), Quaternion.identity);
        Instantiate(enemyShipNr5, new Vector2(-0.8f, 24f), Quaternion.identity);
        Instantiate(enemyShipNr5, new Vector2(0.8f, 24f), Quaternion.identity);
    }

    void EnemyNr6Spawn()
    {
        Instantiate(enemyShipNr6, new Vector2(-10, 7), Quaternion.identity);
        Instantiate(enemyShipNr6, new Vector2(-6, 9), Quaternion.identity);
        Instantiate(enemyShipNr6, new Vector2(0, 10), Quaternion.identity);
        Instantiate(enemyShipNr6, new Vector2(6, 9), Quaternion.identity);
        Instantiate(enemyShipNr6, new Vector2(10, 7), Quaternion.identity);
    }

    void BossNr1Spawn()
    {
        Instantiate(bossShipNr1, new Vector2(0, 8f), Quaternion.identity);
        Instantiate(bossNr1Ram, new Vector2(0, 8f), Quaternion.identity);
    }

    void BossNr2Spawn()
    {
        GameObject boss2 = (GameObject)Instantiate(bossShipNr2, new Vector2(0, 8f), Quaternion.identity);
        if (!GameObject.Find("FirstBoss2")){

            boss2.name = "FirstBoss2";

        }
    }

}
