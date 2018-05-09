using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour {

    public int AmountOfTree, AmountOfStone;

    public void AddResources(string Type, int Amount)
    {
        if(Type == "Tree")
        {
            AmountOfTree += Amount;
        }
        if (Type == "Stone")
        {
            AmountOfStone += Amount;
        }
    }
}
