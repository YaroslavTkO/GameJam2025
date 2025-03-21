using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    

   
    public void SetText(string text)
    {
        scoreText.text = text;
    }

    public void QuitButton()
    {
        SceneManager.LoadScene(0);
    }
}
