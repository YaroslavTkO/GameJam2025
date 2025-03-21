using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public List<string> TipsList;
    public TextMeshProUGUI tipsText;


    public void SetTip()
    {
        tipsText.text = "Pro tip: " + TipsList[Random.Range(0, TipsList.Count)];
    }
    public void SetText(string text)
    {
        scoreText.text = text;
    }

    public void QuitButton()
    {
        SceneManager.LoadScene(0);
    }
    public void RetryButton()
    {
        SceneManager.LoadScene(1);
    }
}
