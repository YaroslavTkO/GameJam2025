using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LevelsController : MonoBehaviour
{
    public int maxFuelLevel = 0, fuelConsumptionLevel = 0, decelerationLevel = 0, accelerationLevel = 0;
    public TrainStats stats;
    public UnityEngine.UI.Button maxFuel, fuelConsumption, deceleration, acceleration;

    private void Start()
    {
        stats = FindObjectOfType<TrainStats>();
        maxFuel.onClick.AddListener(() => IncreaseLevel(Choice.MAX_FUEL));
        fuelConsumption.onClick.AddListener(() => IncreaseLevel(Choice.FUEL_CONSUMPTION));
        deceleration.onClick.AddListener(() => IncreaseLevel(Choice.DECELERATION));
        acceleration.onClick.AddListener(() => IncreaseLevel(Choice.ACCELERATION));

    }
    public void Method() { }

    public void IncreaseLevel(Choice choice)
    {
        switch (choice)
        {
            case Choice.MAX_FUEL:

                if (stats.money >= 10 * Mathf.Pow(2, maxFuelLevel))
                {
                    stats.money -= (int)(10 * Mathf.Pow(2, maxFuelLevel));
                    stats.maxFuel *= 1.05f;
                    maxFuelLevel++;
                    UiManager.Instance.vars.UpdateVariables((int)(10 * Mathf.Pow(2, maxFuelLevel)), maxFuelLevel + 1, choice);
                }

                break;

            case Choice.FUEL_CONSUMPTION:
                if (stats.money >= 10 * Mathf.Pow(2, fuelConsumptionLevel))
                {
                    stats.money -= (int)(10 * Mathf.Pow(2, fuelConsumptionLevel));
                    stats.fuelConsumption *= 0.95f;
                    fuelConsumptionLevel++;
                    UiManager.Instance.vars.UpdateVariables((int)(10 * Mathf.Pow(2, fuelConsumptionLevel)), fuelConsumptionLevel + 1, choice);

                }

                break;

            case Choice.DECELERATION:
                if (stats.money >= 10 * Mathf.Pow(2, decelerationLevel))
                {
                    stats.money -= (int)(10 * Mathf.Pow(2, decelerationLevel));
                    stats.deccelarationSpeed *= 1.05f;
                    decelerationLevel++;
                    UiManager.Instance.vars.UpdateVariables((int)(10 * Mathf.Pow(2, decelerationLevel)), decelerationLevel + 1, choice);

                }

                break;

            case Choice.ACCELERATION:
                if (stats.money >= 10 * Mathf.Pow(2, accelerationLevel))
                {
                    stats.money -= (int)(10 * Mathf.Pow(2, accelerationLevel));
                    stats.accelerationSpeed *= 1.05f;
                    accelerationLevel++;
                    UiManager.Instance.vars.UpdateVariables((int)(10 * Mathf.Pow(2, accelerationLevel)), accelerationLevel + 1, choice);

                }

                break;

            default:
                break;
        }
        UiManager.Instance.UpdateMoneyText(stats.money.ToString());
    }
}

[System.Serializable]
public enum Choice
{
    MAX_FUEL,
    FUEL_CONSUMPTION,
    DECELERATION,
    ACCELERATION
}
