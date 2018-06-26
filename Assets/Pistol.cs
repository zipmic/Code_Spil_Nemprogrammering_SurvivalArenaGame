using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour {

    public GameObject SpawnPoint;
    public GameObject BulletPrefab;
    public float FireRate = 0.1f;
    public int Ammo = 10;
    public int Damage = 1;
    public Camera PlayerCamera;
    public float BulletSpeed = 10;
    public Text PlayerAmmo;

    private float _fireRateCounter = 0;

    public void AddAmmo(int Amount)
    {
        Ammo += Amount;
    }


    void Update()
    {

        PlayerAmmo.text = "Ammo: " + Ammo;

        _fireRateCounter += Time.deltaTime;
        if (Ammo > 0)
        {
            if (Input.GetMouseButton(0))
            {
                if (_fireRateCounter >= FireRate)
                {
                    GameObject spawn = Instantiate(BulletPrefab) as GameObject;
                    spawn.transform.position = SpawnPoint.transform.position;
                    spawn.transform.up = PlayerCamera.transform.forward;
                    spawn.GetComponent<PistolBullet>().Damage = Damage;
                    spawn.GetComponent<PistolBullet>().Speed = BulletSpeed;
                    Ammo -= 1;
                    _fireRateCounter = 0; 

                }
            }
        }
    }
}
