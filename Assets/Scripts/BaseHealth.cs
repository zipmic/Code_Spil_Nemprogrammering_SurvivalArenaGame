using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour {

    public int Health = 5;
    public Slider BaseHealthSlider;

    public void TakeDamage(int AmountOfDamage)
    {
        Health -= AmountOfDamage;
        BaseHealthSlider.value = Health;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
