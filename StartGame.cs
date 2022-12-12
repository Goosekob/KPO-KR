using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public GameObject GameStartUI;

    public void GameStart()
    {
        GameStartUI.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
}
