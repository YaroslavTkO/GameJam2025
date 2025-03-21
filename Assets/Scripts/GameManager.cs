using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private int score;
    public int Score
    {
        get { return score; }
        set { score = value; UiManager.Instance.UpdateScoreText($"Score: {value}"); }
    }

    private bool isGameActive = true;
    public bool IsGameActive
    {
        get { return isGameActive; }
        set { isGameActive = value; if (value == false) { SaveRecord(); UiManager.Instance.DeathScreen(score); } }
    }


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
    public void SaveRecord()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if(score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            Debug.Log(PlayerPrefs.GetInt("HighScore"));
            UiManager.Instance.UpdateHighScore();
        }

    }

    public void GameOver()
    {
        if (!IsGameActive)
        {
            Debug.Log($"Гра закінчена!\nРезультат: {Score}");


        }
    }
}
