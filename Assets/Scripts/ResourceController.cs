using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceController : MonoBehaviour {

    public int AmountOfTree, AmountOfStone;

    public Text TextTree;

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

    public void Update()
    {

        TextTree.text = "Wood: " + AmountOfTree;

    }
}
