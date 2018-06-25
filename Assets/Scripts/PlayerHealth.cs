using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int Health = 3;
    public Slider PlayerHealthSlider;

    public void TakeDamage(int AmountOfDamage)
    {
        Health -= AmountOfDamage;
        PlayerHealthSlider.value = Health;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
