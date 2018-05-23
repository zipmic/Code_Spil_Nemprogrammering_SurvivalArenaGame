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

            NavMeshAgent nm = tmp.GetComponent<NavMeshAgent>();

            if (GC.DifficultyLevel == 1)
            {
                nm.speed = 1.8f;
            }
            else if (GC.DifficultyLevel == 2)
            {
                nm.speed = 2.4f;
                MinSpawnTime = 4;
                MaxSpawnTime = 13;
            }
            else if (GC.DifficultyLevel == 3)
            {
                nm.speed = 3f;
                MinSpawnTime = 3;
                MaxSpawnTime = 10;
            }
            else if (GC.DifficultyLevel == 4)
            {
                nm.speed = 3.8f;
                MinSpawnTime = 3;
                MaxSpawnTime = 8;
            }
            else if (GC.DifficultyLevel == 5)
            {
                nm.speed = 5f;
                MinSpawnTime = 3;
                MaxSpawnTime = 7;
            }
            else
            {
                nm.speed = 5f;
                MinSpawnTime = 3;
                MaxSpawnTime = 7;
            }
                


        }

		
	}
}
