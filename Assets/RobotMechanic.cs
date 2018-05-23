using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotMechanic : MonoBehaviour {

    private GameObject BaseTarget;
    private GameObject Player;

    private float DistanceBeforePlayerTarget = 14;

    public GameObject SmokeExplosion;


    private NavMeshAgent agent;

    private bool UpdateSetDistance = true, TargetingPlayer = false;

    private GameController GC;



	// Use this for initialization
	void Start () {

        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player");
        BaseTarget = GameObject.Find("Base");
        GC = GameObject.Find("Controllers").GetComponent<GameController>();
		
	}
	
	// Update is called once per frame
	void Update () {



        if (Vector3.Distance(transform.position, Player.transform.position) > DistanceBeforePlayerTarget && TargetingPlayer == false)
        {
            if (UpdateSetDistance)
            {
                if (BaseTarget.transform != null)
                {
                    agent.SetDestination(BaseTarget.transform.position);
                    UpdateSetDistance = false;
                }
            }
        }
        else
        {
            UpdateSetDistance = true;
            TargetingPlayer = true;
            agent.SetDestination(Player.transform.position);
        }

        if (Vector3.Distance(transform.position, Player.transform.position) > 21)
        {
            TargetingPlayer = false;

        }

        if (Vector3.Distance(transform.position, Player.transform.position) < 2f)
        {
            GameObject tmp = Instantiate(SmokeExplosion) as GameObject;
            tmp.transform.position = transform.position;
            GC.GameOver();
            Destroy(gameObject);
        }

       

        if (Vector3.Distance(transform.position, BaseTarget.transform.position) < 1)
        {
            GameObject tmp = Instantiate(SmokeExplosion) as GameObject;
            tmp.transform.position = transform.position;

            BaseTarget.GetComponent<BaseHealth>().Damage();
            Destroy(gameObject);
        }
		
	}

    public void Die()
    {
        GameObject tmp = Instantiate(SmokeExplosion) as GameObject;
        tmp.transform.position = transform.position;
        Destroy(gameObject);
    }
}
