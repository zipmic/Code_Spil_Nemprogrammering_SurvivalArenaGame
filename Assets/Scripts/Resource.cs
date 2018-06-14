using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {

    public bool isTree; 
    public bool isStone;

    public int AmountOfResourcesPerHit;

    public int Health = 5;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            // test!
            Hit();
        }
    }

	public void Hit()
    {
        // Sende resources til resource controlleren

        // Give skade
        Health -= 1;

        if (isTree)
        {
            GameObject.Find("ResourceController").GetComponent<ResourceController>().AddResource(AmountOfResourcesPerHit, "wood");
        }
        else if (isStone)
        {
            GameObject.Find("ResourceController").GetComponent<ResourceController>().AddResource(AmountOfResourcesPerHit, "stone");
        }

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
		
	}

}
