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

    public GameObject gameOverScreen;
    public bool IsGameActive = true;


    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        gameOverScreen.SetActive(false);
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

    public void DeathScreen(int score)
    {
        
        gameOverScreen.SetActive(true);
        gameOverScreen.GetComponent<DeathScreen>().SetText("Score: " + score.ToString());
    }
}
