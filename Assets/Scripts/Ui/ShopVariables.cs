using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;
using static LevelsController;

[System.Serializable]
public class ShopVariables
{
    public TextMeshProUGUI maxFuelCost;
    public TextMeshProUGUI fuelConsumptionCost;
    public TextMeshProUGUI decelerationCost;
    public TextMeshProUGUI accelerationCost;

    public TextMeshProUGUI maxFuelLevel;
    public TextMeshProUGUI fuelConsumptionLevel;
    public TextMeshProUGUI decelerationLevel;
    public TextMeshProUGUI accelerationLevel;

    public void UpdateVariables(int newCost, int newLevel, Choice choice)
    {
        switch (choice)
        {
            case Choice.MAX_FUEL:
                maxFuelCost.text = newCost.ToString() + " coins";
                maxFuelLevel.text = "Level " + newLevel.ToString();

                break;
            case Choice.FUEL_CONSUMPTION:
                fuelConsumptionCost.text = newCost.ToString() + " coins";
                fuelConsumptionLevel.text = "Level " + newLevel.ToString();
                break;
            case Choice.DECELERATION:
                decelerationCost.text = newCost.ToString() + " coins";
                decelerationLevel.text ="Level " + newLevel.ToString();
                break;
            case Choice.ACCELERATION:
                accelerationCost.text = newCost.ToString() + " coins";
                accelerationLevel.text = "Level " + newLevel.ToString();
                break;

            default:
                break;


        }


    }


}
