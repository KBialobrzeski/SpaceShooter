using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

    public static int points;
    private long buforPoints;

	void Start () {

        points = 0;
        buforPoints = points;

	}
	
	void Update () {

        this.gameObject.GetComponent<TextMesh>().text = "Points: " + points.ToString();

        if(buforPoints != points)
        {
            StartCoroutine("Wfs");
            buforPoints = points;
        }

    }

    IEnumerator Wfs()
    {
        this.gameObject.transform.localScale = new Vector2(0.065f, 0.065f);
        yield return new WaitForSeconds(0.05f);
        this.gameObject.transform.localScale = new Vector2(0.05f, 0.05f);
    }
}
