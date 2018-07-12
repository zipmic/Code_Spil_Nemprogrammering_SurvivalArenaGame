using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour {

    public int Health = 5;
    public Slider BaseHealthSlider;
	public GameObject DeathScreen;

    public void TakeDamage(int AmountOfDamage)
    {
        Health -= AmountOfDamage;
        BaseHealthSlider.value = Health;

        if (Health <= 0)
        {
			DeathScreen.SetActive(true);
			DeathScreen.transform.Find("Info").GetComponent<Text>().text = "Your base was destroyed!";

		}
    }
}
