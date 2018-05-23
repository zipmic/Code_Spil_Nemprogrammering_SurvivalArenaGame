using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour {

    public int Health = 3;
    public GameController GC;

	// Use this for initialization
	public void Damage () {
		
        Health -= 1;
        if (Health <= 0)
        {
            GC.BaseDestroyed();
            Destroy(gameObject);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
