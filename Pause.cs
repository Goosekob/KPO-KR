using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool ispause;
    public GameObject GamePause;

    void Start()
    {
        ispause = false;
    }

    public void PauseGame()
    {
        ispause = true;
        GamePause.SetActive(true);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && ispause == false)
        {
            ShowPause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && ispause == true)
        {
            HidePause();
        }

        if (ispause == true)
        {
            Time.timeScale = 0;
        }
        else if (ispause == false)
        {
            Time.timeScale = 1.0f;
        }
    }

    public void HidePause()
    {
        ispause = false;
        GamePause.SetActive(false);
    }

    public void ShowPause()
    {
        ispause = true;
        GamePause.SetActive(true);
    }

    public void Resume()
    {
        HidePause();
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
    }

    public void Restart()
    {
        ispause = false;
        SceneManager.LoadScene("Game");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
}
