using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    public static UiManager Instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI fuelText;


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
