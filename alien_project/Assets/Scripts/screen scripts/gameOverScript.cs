using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverScript : MonoBehaviour
{
    public void ScoreScreen()
    {
        gameObject.SetActive(true);
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
