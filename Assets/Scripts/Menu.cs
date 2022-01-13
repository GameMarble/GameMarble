using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameData gameData;

    public void ContinueGame()
    {
        if (PlayerPrefs.GetInt("isDataSaved") == 1)
        {
            PlayerPrefs.SetInt("isContinued", 1);
            SceneManager.LoadScene(PlayerPrefs.GetInt("lastSceneIndex"));
        }
        else
            NewGame();
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene("MainScene");
    }

    public void LoadRandomArena() // Kullanýlmýyor
    {
        PlayerPrefs.DeleteAll();
        
        int sceneIndex = Random.Range(1, 3);
        
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
