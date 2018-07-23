using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceController : MonoBehaviour {

    public int AmountOfStone, AmountOfWood;

    public Text AmountOfStoneText, AmountOfWoodText;

    public void AddResource(int Amount, string Type)
    {
        if (Type == "wood")
        {
            AmountOfWood += Amount;
            AmountOfWoodText.text = "" + AmountOfWood;
        }

        if (Type == "stone")
        {
            AmountOfStone += Amount;
            AmountOfStoneText.text = "" + AmountOfStone;
        }
    }
}
