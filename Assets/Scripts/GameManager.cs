using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject pauseButton;
    public GameObject GameEndingUI;

    public AudioSource audioSource;

    public GameObject player1;
    public GameObject player2;  
    public int scorep1;
    public int scorep2;
    
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
        SceneManager.LoadScene(1);
    }

    public void LoadNextScene()
    {
        // next round butonuna basınca skorlar kaybolduğu için 
        // dolaylı olarak kaydedip önceki sahneden gelen skoru aktarmak için yazıldı.
        scorep1  = PlayerPrefs.GetInt("scoreP1");
        scorep2  = PlayerPrefs.GetInt("scoreP2");

        PlayerPrefs.DeleteAll();
        // next round butonuna basınca skorlar kaybolduğu için 
        // dolaylı olarak kaydedip önceki sahneden gelen skoru aktarmak için yazıldı.
        PlayerPrefs.SetInt("scoreP1", scorep1);
        PlayerPrefs.SetInt("scoreP2", scorep2);
        
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
        
        GameEndingUI.SetActive(true);

    }

    public void NewGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
