using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHunger : MonoBehaviour {

    public Slider HungerSlider;
    public PlayerHunger PlayerHunger;


	// Update is called once per frame
	void Update () {

        HungerSlider.value = PlayerHunger.GetHunger();
		
	}
}
