using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    void Start()
    {
        Time.timeScale = 1f;

        if (PlayerPrefs.GetInt("isContinued") == 1)
        {
            LoadData();
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("xPositionPlayer1", player1.transform.position.x);
        PlayerPrefs.SetFloat("yPositionPlayer1", player1.transform.position.y);
        PlayerPrefs.SetFloat("zPositionPlayer1", player1.transform.position.z);

        PlayerPrefs.SetFloat("xPositionPlayer2", player2.transform.position.x);
        PlayerPrefs.SetFloat("yPositionPlayer2", player2.transform.position.y);
        PlayerPrefs.SetFloat("zPositionPlayer2", player2.transform.position.z);

        PlayerPrefs.SetInt("healthP1", player1.GetComponent<Player>().currentHealth);
        PlayerPrefs.SetInt("healthP2", player2.GetComponent<Player>().currentHealth);

        PlayerPrefs.SetInt("canP1", player1.GetComponent<Player>().can);
        PlayerPrefs.SetInt("canP2", player2.GetComponent<Player>().can);

        PlayerPrefs.SetInt("lastSceneIndex", SceneManager.GetActiveScene().buildIndex);

        PlayerPrefs.SetInt("isDataSaved", 1);
    }

    public void LoadData()
    {
        player1.transform.position = new Vector3(PlayerPrefs.GetFloat("xPositionPlayer1"), PlayerPrefs.GetFloat("yPositionPlayer1"), PlayerPrefs.GetFloat("zPositionPlayer1"));
        player2.transform.position = new Vector3(PlayerPrefs.GetFloat("xPositionPlayer2"), PlayerPrefs.GetFloat("yPositionPlayer2"), PlayerPrefs.GetFloat("zPositionPlayer2"));

        player1.GetComponent<Player>().currentHealth = PlayerPrefs.GetInt("healthP1");
        player2.GetComponent<Player>().currentHealth = PlayerPrefs.GetInt("healthP2");
    }
}
