using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverScript : MonoBehaviour
{
    public Text scoreText;

    public void ScoreScreen(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = score.ToString() + " POINTS"; 
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("game");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
