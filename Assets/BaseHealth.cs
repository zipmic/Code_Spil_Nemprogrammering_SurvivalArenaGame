using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour {

    public int Health = 3;
    public GameController GC;
    public Text AlertText;

	// Use this for initialization
	public void Damage () {
		
        Health -= 1;
        if (Health <= 0)
        {
            GC.BaseDestroyed();
            Destroy(gameObject);
        }

	}
	
	// Update is called once per frame
    void OnTriggerStay(Collider other) 
    {

    
        AlertText.gameObject.SetActive(false);

        if (other.tag == "Enemy")
        {
            AlertText.gameObject.SetActive(true);
        }
		
	}
}
