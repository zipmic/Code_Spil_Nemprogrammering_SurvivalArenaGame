using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour 
{
    public int WeaponIndex = 0;


    // Axe
    public GameObject AxeReference;
    public GameObject PistolReference;

    // Reference til resource controller

    public ResourceController ResourceControllerRef;

    public float AxeHitDelay = 0.1f, PistolHitDelay = 0.1f;
    private float AxeHitDelayCounter = 0, PistolHitDelayCounter = 0;

    bool PlacingTurret = false;
    public GameObject TurretPlaceHolder;

    public GameObject TurretPrefab;

    public LayerMask TerrainMask;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {


        if (Input.GetKeyDown(KeyCode.E) && PlacingTurret == false)
        {
            if (ResourceControllerRef.AmountOfTree >= 100)
            {
                PlacingTurret = true;
            }
        }
        else if (PlacingTurret)
        {
            if (ResourceControllerRef.AmountOfTree >= 100)
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 7, TerrainMask))
                {
                
                    TurretPlaceHolder.gameObject.SetActive(true);
                    TurretPlaceHolder.transform.position = hit.point + Vector3.up * 0.5f;
                    TurretPlaceHolder.transform.forward = transform.forward;


                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject t = Instantiate(TurretPrefab) as GameObject;
                    t.transform.position = hit.point + Vector3.up * 0.5f;
                    t.transform.forward = transform.forward;
                    t.name = "Turret";

                    ResourceControllerRef.AmountOfTree -= 100;

                    PlacingTurret = false;
                    TurretPlaceHolder.SetActive(false);
                }
            }
            
        }

        AxeHitDelayCounter += Time.deltaTime;
        PistolHitDelayCounter += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponIndex = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WeaponIndex = 1;
        }


        if (WeaponIndex == 0)
        {
            AxeReference.gameObject.SetActive(true);
            PistolReference.gameObject.SetActive(false);
            // Axe
            if (Input.GetMouseButtonDown(0) && AxeHitDelayCounter > AxeHitDelay)
            {

                AxeHitDelayCounter = 0; 

                AxeReference.GetComponent<Animator>().Play("Hit");
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5))
                {
                    

                    if (hit.collider.tag == "Tree")
                    {
                       
                        hit.collider.gameObject.GetComponent<Resource>().HitAndCollectResource("Tree", 1);
                    }
                        
                }
            }

        }


        if (WeaponIndex == 1)
        {
            AxeReference.gameObject.SetActive(false);
            PistolReference.gameObject.SetActive(true);
            // Pistol
            if (Input.GetMouseButtonDown(0) && PistolHitDelayCounter > PistolHitDelay)
            {

                PistolHitDelayCounter = 0; 

                AxeReference.GetComponent<Animator>().Play("Hit");

                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 100))
                {

                    if (hit.collider.tag == "Enemy")
                    {
                        Destroy(hit.collider.gameObject);
                    }

                }
            }
        }


       
		
	}
}
