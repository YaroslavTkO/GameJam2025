using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    public static UiManager Instance;

    public Text scoreText;
    public Text moneyText;
    public Text fuelText;


    public bool IsGameActive = true;


    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateMoneyText(string newMoney)
    {
        moneyText.text = newMoney;
    }
    public void UpdateScoreText(string newScore)
    {
        scoreText.text = newScore;
        
    }

    public void UpdateFuelText(string newFuel)
    {
        fuelText.text = newFuel;
    }
}
