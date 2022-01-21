using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
