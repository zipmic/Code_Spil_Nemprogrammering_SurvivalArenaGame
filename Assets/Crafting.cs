using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour {

    public GameObject CraftingMenu;

	// Use this for initialization
	void Start () {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
		
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
