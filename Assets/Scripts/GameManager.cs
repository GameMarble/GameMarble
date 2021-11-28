using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject pauseButton;
    public GameObject GameEndingUI;

    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameEnded()
    {
        GameEndingUI.SetActive(true);
    }

}
