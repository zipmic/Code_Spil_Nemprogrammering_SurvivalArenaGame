using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHunger : MonoBehaviour {


    private float _hunger = 100;
    public float _rateOfHunger = 1;

    public float GetHunger()
    {
        return _hunger;
    }
	
	// Update is called once per frame
	void Update () {

        _hunger -= _rateOfHunger*Time.deltaTime;
        if (_hunger <= 0)
        {
            _hunger = 0;
        }
		
	}
}
