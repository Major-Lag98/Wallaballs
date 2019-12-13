using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool paused = false;

    public GameObject pauseMenu;
    public Scene menu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //pause
        {
            if (paused)
            {
                cont();
            }
            else pause();
        }
    }
    void pause()
    {
        pauseMenu.SetActive(true);
        Debug.Log("Pauseing...");
        Time.timeScale = 0;
        paused = true;
    }
    public void cont()
    {
        pauseMenu.SetActive(false);
        Debug.Log("Resuming...");
        Time.timeScale = 1;
        paused = false;
    }
    public void LoadMenu()
    {
        Debug.Log("Loading Menu...");
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void Retry()
    {
        Debug.Log("Retrying...");
        SceneManager.LoadScene("GameScene");
    }
}
