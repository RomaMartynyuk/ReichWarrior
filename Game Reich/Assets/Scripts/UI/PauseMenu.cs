using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject player;
    private bool pauseActive = false;
    public Scene currentMission;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseActive)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        player.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pauseActive = false;
    }
    void Pause()
    {
        player.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pauseActive = true;
    }
    public void GoMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
