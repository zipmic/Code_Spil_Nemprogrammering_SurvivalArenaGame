using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour {

    public Transform Pivot;

    private Transform Target;

    public GameObject PrefabBullet;
    public GameObject SpawnPoint;

    private float counter = 0;

    private int DeathCounter = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // check for enemies
        if (Target != null)
        {
            Pivot.LookAt(Target);

            counter += Time.deltaTime;

            if (counter > 5f)
            {
                GameObject tmp = Instantiate(PrefabBullet) as GameObject;
                tmp.transform.position = SpawnPoint.transform.position;
                tmp.transform.forward = SpawnPoint.transform.forward;
                tmp.GetComponent<Rigidbody>().velocity = SpawnPoint.transform.forward * 40;

                Destroy(tmp, 5);

                counter = 0;

                DeathCounter += 1;

                if (DeathCounter >= 30)
                {
                    Destroy(gameObject);
                }
            }
        }

		
	}

    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Enemy")
        {
            
            if (Target == null)
            {
                Target = other.transform;
            }
        }
    }
}
