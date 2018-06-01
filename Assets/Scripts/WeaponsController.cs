using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsController : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

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
