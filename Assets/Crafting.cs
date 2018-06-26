using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour {

    public GameObject CraftingMenu;
    public ResourceController ResourceControllerRef;
    public WeaponsController WeaponsController;
    public Pistol PistolRef;
    public Button PistolButton;


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

    public void BuyAmmo()
    {
        if (ResourceControllerRef.AmountOfWood >= 10)
        {
            ResourceControllerRef.AddResource(-10, "wood");
            PistolRef.AddAmmo(10);

        }
    }

    public void BuyPistol()
    {
        if (ResourceControllerRef.AmountOfStone >= 50)
        {
          
            ResourceControllerRef.AddResource(-50, "stone");
            PistolButton.interactable = false;
            WeaponsController.PistolEnabled = true;
            CraftingMenu.SetActive(false);
            WeaponsController.SetSelectedWeapon(2);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
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
