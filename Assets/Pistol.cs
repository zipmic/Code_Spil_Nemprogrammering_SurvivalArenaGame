using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour {

    public GameObject SpawnPoint;
    public GameObject BulletPrefab;
    public float FireRate = 0.1f;
    public int Ammo;
    public int Damage = 1;
    public Camera PlayerCamera;
    public float BulletSpeed = 10;

    private float _fireRateCounter = 0;


    void Update()
    {
        _fireRateCounter += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (_fireRateCounter >= FireRate)
            {
                GameObject spawn = Instantiate(BulletPrefab) as GameObject;
                spawn.transform.position = SpawnPoint.transform.position;
                spawn.transform.up = PlayerCamera.transform.forward;
                spawn.GetComponent<PistolBullet>().Damage = Damage;
                spawn.GetComponent<PistolBullet>().Speed = BulletSpeed;

                _fireRateCounter = 0; 

            }
        }
    }
}
