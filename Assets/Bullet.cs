﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {

        if (other.tag == "Enemy")
        {
            other.GetComponent<RobotMechanic>().Die();
            Destroy(gameObject);
        }
		
	}
}
