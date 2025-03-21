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
            passengers += stationBonuses.passengers;
            if (passengers > maxPassengers)
            {
                passengers = maxPassengers;
            }
        }
        fuel += stationBonuses.fuel;
       
        if (fuel > maxFuel)
            fuel = maxFuel;
        

        stationBonuses.passengers = 0;
        stationBonuses.fuel = 0;

    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameActive)
        {
            fuel -= Time.deltaTime * fuelConsumption;
            if (fuel <= 0)
            {
                GameManager.Instance.IsGameActive = false;
                GameManager.Instance.GameOver();
            }


            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log($"----------Current stats------------\nMoney: {money}\nPassenger: {passengers}\nFuel: {fuel}");

            }
        }

    }
}
