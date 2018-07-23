using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GameObject EnemyPrefab;
    public float MinInterval, MaxInterval;

    public bool isRunning;
    public int CurrentDay = 1;

    private float _randomInterval; 
    private float _counter = 0;
    private GameObject _player;

	// Use this for initialization
	void Start () {

        _player = GameObject.Find("StationLargeCenter");

        _randomInterval = Random.Range(MinInterval, MaxInterval);

		
	}
	
	// Update is called once per frame
	void Update () {

        if (isRunning)
        {
            _counter += Time.deltaTime;

            if (_counter >= _randomInterval)
            {
                GameObject spawn = Instantiate(EnemyPrefab) as GameObject;
                spawn.GetComponent<Enemy>().Target = _player;
                spawn.transform.position = transform.position;

                _counter = 0;
                _randomInterval = Random.Range(MinInterval, MaxInterval);

            }
        }
		
	}
}
