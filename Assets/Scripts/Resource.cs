using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {

    public int MinResourcePerHit;
    public int MaxResourcePerhit;

    public int Health;

    private ResourceController _resourceControllerRef;

    void Start()
    {
        _resourceControllerRef = GameObject.FindObjectOfType<ResourceController>();
    }

    public void HitAndCollectResource(string type, int Damage)
    {
        Health -= Damage;

        if (type == "Tree")
        {
            _resourceControllerRef.AddResources("Tree", Random.Range(MinResourcePerHit, MaxResourcePerhit));
        }
     


        if (Health <= 0)
        {
            StartCoroutine(WaitAndRespawn());   
        }
      
          
       
    }

    IEnumerator WaitAndRespawn()
    {
        Collider c = GetComponent<Collider>();
        MeshRenderer mr = GetComponentInChildren<MeshRenderer>();

        c.enabled = false;
        mr.enabled = false;
        yield return new WaitForSeconds(15);
        mr.enabled = true;
        c.enabled = true;
        Health = 5;
       

    }

}
