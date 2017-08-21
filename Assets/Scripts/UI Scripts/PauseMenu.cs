using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
	}

    public void Toggle ()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Toggle();
    }
    public void Menu ()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
