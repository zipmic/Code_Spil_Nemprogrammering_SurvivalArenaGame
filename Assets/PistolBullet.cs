using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour {

    public int Damage;
    public float Speed;

    private Rigidbody _rb;

	// Use this for initialization
	void Start () {
		
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = transform.up * Speed;
        Destroy(gameObject, 4);
	}
	
	// Update is called once per frame
    void OnCollisionEnter(Collision other) {
      
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(Damage);
        }

        Destroy(gameObject);
		
	}
}
