using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berries : MonoBehaviour {

    public float AmountOfHunger = 10;
    public float TimeBeforeReset = 5;
    public GameObject AllTheBerries;

    private bool _isAbleToGetBerries = true;
    private float _resetCounter;

    void Update()
    {
        if (_isAbleToGetBerries == false)
        {
            _resetCounter += Time.deltaTime;

            if (_resetCounter >= TimeBeforeReset)
            {
                _resetCounter = 0;
                _isAbleToGetBerries = true;
                AllTheBerries.SetActive(true);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && _isAbleToGetBerries)
            {
                other.GetComponent<PlayerHunger>().AddHunger(AmountOfHunger);
                AllTheBerries.SetActive(false);
                _isAbleToGetBerries = false;
            }

        }
    }
}
