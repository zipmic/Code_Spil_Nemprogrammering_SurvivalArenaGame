using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public GameObject Target;
    private NavMeshAgent _navAgent;

    public int AmountOfDamage = 1;

	public GameObject ExplosionPrefab;

	// Use this for initialization
	void Start () {
        _navAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		

        _navAgent.SetDestination(Target.transform.position);

	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Base")
        {
            other.gameObject.GetComponent<BaseHealth>().TakeDamage(AmountOfDamage);

			GameObject tmp = Instantiate(ExplosionPrefab) as GameObject;
			tmp.transform.position = transform.position;
			Destroy(tmp, 4);
		
			Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(AmountOfDamage);
			GameObject tmp = Instantiate(ExplosionPrefab) as GameObject;
			tmp.transform.position = transform.position;
			Destroy(tmp, 4);
			Destroy(gameObject);
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Target = other.gameObject;
        }
    }
}
