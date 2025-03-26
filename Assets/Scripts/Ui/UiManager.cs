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
    public TextMeshProUGUI moneyText2;
    public TextMeshProUGUI fuelText;
    public TextMeshProUGUI passengersText;
    public TextMeshProUGUI highScoreText;

    public ShopVariables vars;
    


    public GameObject gameOverScreen;
    public GameObject shop;
    public GameObject shopButton;


    public AudioSource clickSound;

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
        UpdateHighScore();
    }

    public void UpdateMoneyText(string newMoneyString)
    {
        moneyText.text = newMoneyString;
        moneyText2.text = newMoneyString;
    }
    public void UpdateScoreText(string newScoreString)
    {
        scoreText.text = newScoreString;
        
    }

    public void UpdateFuelText(string newFuelString)
    {
        fuelText.text = newFuelString;
    }

    public void UpdatePassengerText(string newPassangerString)
    {
        passengersText.text = newPassangerString;
       
    }

    public void DeathScreen(int score)
    {
        
        gameOverScreen.SetActive(true);
        gameOverScreen.GetComponent<DeathScreen>().SetText("Score: " + score.ToString());
        gameOverScreen.GetComponent<DeathScreen>().SetTip();
    }

    public void ShopChangeVisibility(bool newVisibility)
    {
        shop.SetActive(newVisibility);
    }

    public void ShopButtonChangeVisibility(bool newVisibility)
    {
        shopButton.SetActive(newVisibility);
    }

    public void UpdateHighScore()
    {
        highScoreText.text = $"High score: {PlayerPrefs.GetInt("HighScore", 0)}";
    
    }

    public void ClickSoundEffect()
    {
        clickSound.Play();
    }
}
