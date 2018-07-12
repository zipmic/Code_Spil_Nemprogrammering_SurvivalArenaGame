using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSystem : MonoBehaviour {

    public float CycleValue = 0;

    public GameObject[] ArrayOfSpawnControllers;

    private int _day = 1;
    private bool _night1, _night2, _night3;

	public GameObject WinScreen;

    // day 1 - 0 til 180 
    // night 1 - 180 - 360
  // day 2 - 360 - 540
    // night 2 - 540 - 720
   // day 3 - 720 - 900
    // night 3 - 900 til 1080



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        CycleValue += Time.deltaTime*2;
        transform.rotation = Quaternion.Euler(CycleValue, -30, 0);

        if (_day == 1)
        {
            if (CycleValue >= 180 && _night1 == false)
            {
                _night1 = true;
                foreach (GameObject go in ArrayOfSpawnControllers)
                {
                    go.GetComponent<SpawnController>().isRunning = true;
                }
            }
            if (CycleValue >= 360 && _night1 == true)
            {
                _night1 = false;
                _day = 2;
                foreach (GameObject go in ArrayOfSpawnControllers)
                {
                    go.GetComponent<SpawnController>().isRunning = false;
                }
            }
        }
        if (_day == 2)
        {
            if (CycleValue >= 540 && _night1 == false)
            {
                _night1 = true;
                foreach (GameObject go in ArrayOfSpawnControllers)
                {
                    go.GetComponent<SpawnController>().isRunning = true;
                }
            }
            if (CycleValue >= 720 && _night1 == true)
            {
                _night1 = false;
                _day = 3;
                foreach (GameObject go in ArrayOfSpawnControllers)
                {
                    go.GetComponent<SpawnController>().isRunning = false;
                }
            }
        }
        if (_day == 3)
        {
            if (CycleValue >= 900 && _night1 == false)
            {
                _night1 = true;
                foreach (GameObject go in ArrayOfSpawnControllers)
                {
                    go.GetComponent<SpawnController>().isRunning = true;
                }
            }
            if (CycleValue >= 1080 && _night1 == true)
            {
                _night1 = false;
                _day = 3;
                foreach (GameObject go in ArrayOfSpawnControllers)
                {
                    go.GetComponent<SpawnController>().isRunning = false;
                }
            }
        }


		if (CycleValue >= 1080)
		{
			WinScreen.SetActive(true);
		}
		
	}
}
