using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour 
{
    public int WeaponIndex = 0;


    // Axe
    public GameObject AxeReference;

    // Reference til resource controller

    public ResourceController ResourceControllerRef;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (WeaponIndex == 0)
        {

            AxeReference.gameObject.SetActive(false);
        }

        if (WeaponIndex == 1)
        {
            AxeReference.gameObject.SetActive(true);
            // Axe
            if (Input.GetMouseButtonDown(0))
            {
                AxeReference.GetComponent<Animator>().Play("Hit");
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5))
                    {

                    if (hit.collider.tag == "Tree")
                    {
                       
                        hit.collider.gameObject.GetComponent<Resource>().HitAndCollectResource("Tree", 1);
                    }
                        
                    }
            }
        }


       
		
	}
}
