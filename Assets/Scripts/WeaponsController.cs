using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsController : MonoBehaviour {

    public Animator AxeAnimator;
    public LayerMask TurretHitMask;
    public ResourceController ResourceControllerRef;

    public GameObject TurretPrefab;
    public Camera FPSCamera;

    private float _axeInterval = 0.3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        _axeInterval += Time.deltaTime;

     
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ResourceControllerRef.AmountOfStone >= 50)
            {
                ResourceControllerRef.AddResource(-50, "stone");

                RaycastHit TerrainHit; 
                if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out TerrainHit, 10, TurretHitMask))
                {
                    GameObject SpawnedTurret = Instantiate(TurretPrefab) as GameObject;
                    SpawnedTurret.transform.position = TerrainHit.point;
                    SpawnedTurret.transform.forward = FPSCamera.transform.parent.transform.forward;
                }
            }

        }


        if (_axeInterval > 0.3f)
        {
            if (Input.GetMouseButtonDown(0))
            {

                AxeAnimator.Play("Axe_Swing");
                _axeInterval = 0;

                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
                {
           
                    if (hit.transform.tag == "resource")
                    {
                        hit.transform.GetComponent<Resource>().Hit();
                    }
           
                }
            }
        }
		
	}
}
