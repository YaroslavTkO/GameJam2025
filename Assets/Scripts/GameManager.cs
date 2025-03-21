using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private int score;
    public int Score {  get { return score; }
    set { score = value; UiManager.Instance.UpdateScoreText($"Score: {value}"); }
    }

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

    public void GameOver()
    {
        if (!IsGameActive)
        {
            Debug.Log($"Гра закінчена!\nРезультат: {Score}");


        }
    }
}
