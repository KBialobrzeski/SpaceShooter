using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour {

    Image healtbar;
    private float maxHealth;
    private float health;

	void Start () {

            healtbar = GetComponent<Image>();
            maxHealth = BossNr1.lifePoints;
        
    }
	
	void Update () {

        health = BossNr1.lifePoints;
        healtbar.fillAmount = health / maxHealth;
		
	}
}
