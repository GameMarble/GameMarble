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
            SceneManager.LoadScene(1);
        }
        else
            SceneManager.LoadScene("MainScene");
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
