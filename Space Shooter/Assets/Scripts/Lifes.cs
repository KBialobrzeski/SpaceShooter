using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : MonoBehaviour {

    private int lifes = 1;
    public GameObject endGame;
    public float time;

    private float timer = 0;
    private float timerMax = 0;

    void Start () {

        lifes = PlayerShipManager.healthPoints;

	}
	
	void FixedUpdate () {

        lifes = PlayerShipManager.healthPoints;
        this.gameObject.GetComponent<TextMesh>().text = "Lives: " + lifes.ToString();

        if(lifes <= 0)
        {

            if (Waited(2))
            {
                EndGame();
                timer = 0;
            }
            
        }

    }

    void EndGame()
    {

        endGame.SetActive(!endGame.activeInHierarchy);

        Time.timeScale = 0;
        Cursor.visible = true;
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
