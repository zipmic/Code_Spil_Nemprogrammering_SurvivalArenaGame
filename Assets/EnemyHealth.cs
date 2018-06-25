using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int Health = 1;

	// Use this for initialization
    public void TakeDamage (int Damage) {
        Health -= Damage;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
		
	}
	
}
