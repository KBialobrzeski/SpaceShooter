using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ram : MonoBehaviour {

    void FixedUpdate()
        {
        this.gameObject.transform.position = GameObject.FindGameObjectWithTag("Boss").transform.position;
        }
}
