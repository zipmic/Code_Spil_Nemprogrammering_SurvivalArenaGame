using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour {

    private Rigidbody _rb;

    public float Speed = 10;

	// Use this for initialization
	void Start () {

        _rb = GetComponent<Rigidbody>();
		
	}

    void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Enemy")
        {
            Destroy(Other.gameObject);
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        _rb.velocity = transform.forward * Speed * Time.deltaTime;
	}


}
