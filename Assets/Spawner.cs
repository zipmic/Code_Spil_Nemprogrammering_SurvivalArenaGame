using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour {

    public GameController GC;
    public GameObject Robot;

    public float MinSpawnTime = 5, MaxSpawnTime = 15;

   

	// Use this for initialization
    IEnumerator Start () 
    {

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(MinSpawnTime, MaxSpawnTime));

            GameObject tmp = Instantiate(Robot) as GameObject;
            tmp.transform.position = transform.position+Vector3.right*(Random.Range(-5,5))+Vector3.forward*Random.Range(-5,5);
            tmp.GetComponent<NavMeshAgent>().enabled = true;

        }

		
	}
}
