using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
