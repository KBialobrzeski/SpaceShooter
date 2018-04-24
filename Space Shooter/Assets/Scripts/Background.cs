using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	public float speed;

	private Vector2 vec;
	
	// Update is called once per frame
	void Update () {

		vec = new Vector2 (0, Time.time * speed);
		GetComponent<Renderer> ().material.mainTextureOffset = vec;
		
	}
}
