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
    private int _selectedWeapon = 1;

    public GameObject WeaponAxe, WeaponPistol;
    public bool PistolEnabled = false;

    private Pistol _pistol;
    private bool _canPlaceTurret = false;

	// Use this for initialization
	void Start () {

        _pistol = GetComponent<Pistol>();
		
	}

    public void PlaceTurret()
    {
        _canPlaceTurret = true;
    }

    public void SetSelectedWeapon(int selectedWeapon)
    {
        _selectedWeapon = selectedWeapon;
        if (selectedWeapon == 2)
        {
            _pistol.enabled = true;
        }
    }
        
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _selectedWeapon = 1;
            _pistol.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (PistolEnabled == true)
            {
                _selectedWeapon = 2;
                _pistol.enabled = true;
            }
        }


        if (_selectedWeapon == 1)
        {
            // Øksen
            WeaponAxe.SetActive(true);
            WeaponPistol.SetActive(false);

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
        else if (_selectedWeapon == 2)
        {
            // pistol
            WeaponAxe.SetActive(false);
            WeaponPistol.SetActive(true);

        }









        _axeInterval += Time.deltaTime;

        if (_canPlaceTurret == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _canPlaceTurret = false;

                RaycastHit TerrainHit; 
                if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out TerrainHit, 10, TurretHitMask))
                {
                    GameObject SpawnedTurret = Instantiate(TurretPrefab) as GameObject;
                    SpawnedTurret.transform.position = TerrainHit.point;
                    SpawnedTurret.transform.forward = FPSCamera.transform.parent.transform.forward;
                }


            }
        }


      
		
	}
}
