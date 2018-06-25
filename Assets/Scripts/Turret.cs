using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public GameObject TurretGun;
    public GameObject SpawnPoint;
    public GameObject TurretBulletPrefab;

    private GameObject _target;

    private float _turretBulletCounter;

  

	// Use this for initialization
	void Update ()
    {
	
        _turretBulletCounter += Time.deltaTime;

        if (_target != null)
        {
            TurretGun.transform.LookAt(_target.transform);

            if (_turretBulletCounter > 0.3f)
            {
                GameObject SpawnedObject = Instantiate(TurretBulletPrefab) as GameObject;
                SpawnedObject.transform.position = SpawnPoint.transform.position;
                SpawnedObject.transform.forward = SpawnPoint.transform.forward;

                _turretBulletCounter = 0;
            

            }
        }

     

	}

    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Enemy")
        {
            if (_target == null)
            {
                _target = other.gameObject;
            }
        }
		
	}
}
