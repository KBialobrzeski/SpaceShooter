using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Up_Moving : MonoBehaviour {
	
	void Update () {
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, GameObject.Find("Player(Clone)").transform.position, 2 * Time.deltaTime);

    }
}
