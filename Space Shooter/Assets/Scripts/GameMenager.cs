using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour {

	public GameObject playerShip;

    public static float multiplier;

	void Start () {

		Instantiate (playerShip, new Vector3 (0, 0, 0), Quaternion.identity);
        Time.timeScale = 1;
        multiplier = 1f;
    }
}
