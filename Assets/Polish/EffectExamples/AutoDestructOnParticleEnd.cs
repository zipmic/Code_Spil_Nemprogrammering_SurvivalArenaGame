using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestructOnParticleEnd : MonoBehaviour {

    private ParticleSystem _ps;


	// Use this for initialization
	void Awake () {
        _ps = GetComponent<ParticleSystem>();
        Destroy(gameObject, _ps.main.duration);
	}
	
	
}
