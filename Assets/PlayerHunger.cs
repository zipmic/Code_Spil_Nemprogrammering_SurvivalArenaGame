using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHunger : MonoBehaviour {


    private float _hunger = 100;
    public float _rateOfHunger = 1;
	public GameObject DeathScreen;

    public float GetHunger()
    {
        return _hunger;
    }

    public void AddHunger(float AmountOfHunger)
    {
        _hunger += AmountOfHunger;
        if (_hunger > 100)
        {
            _hunger = 100;
        }
    }
	
	// Update is called once per frame
	void Update () {

        _hunger -= _rateOfHunger*Time.deltaTime;
        if (_hunger <= 0)
        {
            _hunger = 0;
			DeathScreen.SetActive(true);
			DeathScreen.transform.Find("Info").GetComponent<Text>().text = "You became too hungry and died :(";


		}
		
	}
}
