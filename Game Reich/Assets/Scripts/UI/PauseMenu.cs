using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject player;
    private bool pauseActive = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
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
    void Resume()
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
}
