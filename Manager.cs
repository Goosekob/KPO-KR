using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{
    public GameObject GameOverUI;

    public void GameOver()
    {
        GameOverUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
}

