using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour {

    private float timer = 0;
    private float timerMax = 0;
    private int x;

    void Start () {

        x = 3;
        this.gameObject.GetComponent<TextMesh>().text = x.ToString();

    }

    void Update () {

        if(x < 1)
        {
            this.gameObject.GetComponent<TextMesh>().text = "GO!";
            Destroy(this.gameObject, 1f);
        }
        else if (Waited(1))
        {
            --x;
            this.gameObject.GetComponent<TextMesh>().text = x.ToString();
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
