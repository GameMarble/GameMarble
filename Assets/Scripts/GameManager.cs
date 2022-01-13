using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject pauseButton;
    public GameObject GameEndingUI;

    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        audioSource.Pause();
        pauseButton.SetActive(false);
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        audioSource.Play();
        pauseButton.SetActive(true);
    }

    public void Restart()
    {
        PlayerPrefs.DeleteAll();
        audioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        PlayerPrefs.DeleteAll();
        audioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        PlayerPrefs.DeleteAll();
        audioSource.Pause();
        GameEndingUI.SetActive(true);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadRandomArena()
    {
        PlayerPrefs.DeleteAll();

        int sceneIndex = Random.Range(1,2);

        SceneManager.LoadScene(sceneIndex);
    }
}
