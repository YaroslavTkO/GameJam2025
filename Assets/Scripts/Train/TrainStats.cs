using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainStats : MonoBehaviour
{
    public float maxSpeed;
    public float accelerationSpeed;
    public float deccelarationSpeed;

    public int money;
    public int passengers;
    public int ticketCost;
    public float fuel;
    public float fuelConsumption;


    public float maxFuel;
    public int maxPassengers;

    public bool isOnStation = false;
    public StationStats stationBonuses;


    public void ClaimStationBonus()
    {
        if (stationBonuses.passengers != 0)
        {
            money += passengers * ticketCost;
            if (passengers != 0)
                UiManager.Instance.UpdateMoneyText(money.ToString());
            passengers = stationBonuses.passengers;
            if (passengers > maxPassengers)
            {
                passengers = maxPassengers;
            }
            stationBonuses.passengers = 0;
            UiManager.Instance.UpdatePassengerText($"{passengers}\\{maxPassengers}");
        }
        if (stationBonuses.fuel != 0)
        {
            fuel += stationBonuses.fuel;

            if (fuel > maxFuel)
                fuel = maxFuel;

            UiManager.Instance.UpdateFuelText($" {((int)fuel)}\\{Mathf.Round(maxFuel)}");

            stationBonuses.fuel = 0;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
        if (GameManager.Instance.IsGameActive && !isOnStation)
        {
            fuel -= Time.deltaTime * fuelConsumption;
            UiManager.Instance.UpdateFuelText($" {((int)fuel)}\\{Mathf.Round(maxFuel)}");
            if (fuel <= 0)
            {
                GameManager.Instance.IsGameActive = false;
            }

        }

    }
}
