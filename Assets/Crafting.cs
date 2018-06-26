using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour {

    public GameObject CraftingMenu;
    public ResourceController ResourceControllerRef;
    public WeaponsController WeaponsController;


	// Use this for initialization
	void Start () {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
		
	}

    public void BuyTurret()
    {
        //menu til at forsvinde
        CraftingMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (ResourceControllerRef.AmountOfWood >= 50)
        {
            ResourceControllerRef.AddResource(-50, "wood");
            WeaponsController.PlaceTurret();

        }


    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (CraftingMenu.activeSelf == true)
            {
                CraftingMenu.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                CraftingMenu.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
		
	}
}
