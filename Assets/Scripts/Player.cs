using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;

    public GameManager gameManager;

    public Text winnerText;
    public Text p1HealthNumber;
    public Text p2HealthNumber;
    public Text resultText;
    public Text resultScore;

    public CubeTrigger cubeTrigger;

    public float y_position;
    public int can = 3;
    public int damage = 20;
    public int maxHealth = 100;
    public int currentHealth;
    
    public int scoreP1;
    public int scoreP2;

    public static bool GameHasEnded = false;

    Player p1;
    Player p2;

    public HealthBar healthBar;

    private void Awake()
    {
        scoreP1 = PlayerPrefs.GetInt("scoreP1");
        scoreP2 = PlayerPrefs.GetInt("scoreP2");
    }

    void Start()
    {
        p1 = player1.GetComponent<Player>();
        p2 = player2.GetComponent<Player>();

        if (PlayerPrefs.GetInt("isContinued") != 1)
        {
            PlayerPrefs.DeleteAll();

            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            p1.can = 3;
            p2.can = 3;
            
        }
        else
        {
            p1.currentHealth = PlayerPrefs.GetInt("healthP1");
            p1.healthBar.SetHealth(PlayerPrefs.GetInt("healthP1"));
            p1HealthNumber.text = "Health: " + PlayerPrefs.GetInt("canP1").ToString();

            p2.currentHealth = PlayerPrefs.GetInt("healthP2");
            p2.healthBar.SetHealth(PlayerPrefs.GetInt("healthP2"));
            p2HealthNumber.text = "Health: " + PlayerPrefs.GetInt("canP2").ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
            if(cubeTrigger.triggeredPlayer == "Player1" && player1.transform.position.y < player2.transform.position.y )
            {
                
                scoreP2++;
                PlayerPrefs.SetInt("scoreP2", scoreP2);
                winnerText.text = player2.name + " Won This Round!";
                
                
                //Debug.Log(scoreP1 + " " + scoreP2);
                //Debug.Log("player2 kazandı");

                gameManager.GameEnded();
                GameHasEnded = true;
            }
            else if(cubeTrigger.triggeredPlayer == "Player2" && player1.transform.position.y > player2.transform.position.y )
            {
                
                scoreP1++;
                PlayerPrefs.SetInt("scoreP1", scoreP1);
                // gameManager.GameEnded();
                winnerText.text = player1.name + " Won This Round!";
                
                //Debug.Log(scoreP1 + " " + scoreP2);
                // Debug.Log("player1 kazandı");

                gameManager.GameEnded();
                GameHasEnded = true;
            }
            if(GameHasEnded)
                FinalResult();
    }

    void OnCollisionEnter(Collision collision)
    {
        
        p1.y_position = p1.transform.position.y;
        p2.y_position = p2.transform.position.y;

        if (collision.gameObject.tag == "Player2")
        {   /* player1 aşağıdan çarptı*/
            if(p1.y_position < p2.y_position )
            {
                //Debug.Log("player1 aşağıdan çarptı ve hasar aldı");
                p1.currentHealth -= damage;

                p1.healthBar.SetHealth(p1.currentHealth);
                PlayerPrefs.SetInt("healthP1", p1.currentHealth);

                if (p1.currentHealth == 0)
                {
                    //Debug.Log("player1 can gitti");
                    p1.can--;
                    p1HealthNumber.text = "Health: " + p1.can;
                    p1.currentHealth = p1.maxHealth;
                    p1.healthBar.SetHealth(p1.maxHealth);

                    PlayerPrefs.SetInt("canP1", p1.can);
                    PlayerPrefs.SetInt("healthP1", p1.currentHealth);

                    PlayerPrefs.SetInt("canP2", p2.can);
                    PlayerPrefs.SetInt("healthP2", p2.currentHealth);
                }
                if(p1.can == 0 && p1.currentHealth == 100)
                {
                    //Debug.Log("player2 kazandı");
                    
                    scoreP2++;
                    PlayerPrefs.SetInt("scoreP2", scoreP2);
                    //Debug.Log(scoreP1 + " " + scoreP2);
                    
                    winnerText.text = player2.name + " Won This Round!";

                    gameManager.GameEnded();
                    GameHasEnded = true;
                    
                    if (SceneManager.GetActiveScene().buildIndex == 2)
                        FinalResult();
                }
            }

            else if(p1.y_position > p2.y_position/*player1 yukarıdan çarptı*/)
            {
                //Debug.Log("player1 yukarıdan çarptı ve hasar verdi");
                
                p2.currentHealth -= damage;

                p2.healthBar.SetHealth(p2.currentHealth);
                PlayerPrefs.SetInt("healthP2", p2.currentHealth);

                if (p2.currentHealth == 0 )
                {
                    //Debug.Log("player2 can gitti");
                    p2.can--;
                    p2HealthNumber.text = "Health: " + p2.can;
                    p2.currentHealth = p2.maxHealth;
                    p2.healthBar.SetHealth(p2.maxHealth);

                    PlayerPrefs.SetInt("canP1", p1.can);
                    PlayerPrefs.SetInt("healthP1", p1.currentHealth);

                    PlayerPrefs.SetInt("canP2", p2.can);
                    PlayerPrefs.SetInt("healthP2", p2.currentHealth);
                }
                if(p2.can == 0 && p2.currentHealth == 100)
                {
                    //Debug.Log("player1 kazandı");
                    
                    scoreP1++;
                    PlayerPrefs.SetInt("scoreP1", scoreP1);
                    //Debug.Log(scoreP1 + " " + scoreP2);
                    
                    winnerText.text = player1.name + " Won This Round!";
                    
                    gameManager.GameEnded();
                    GameHasEnded = true;

                    if (SceneManager.GetActiveScene().buildIndex == 2)
                        FinalResult();
                }
            }
        }
    }

    public void FinalResult()
    {
        
        // Debug.Log(scoreP1 + " " + scoreP2);
        if (scoreP1 > scoreP2) // Player 1 kazanır
        {
            resultText.text = p1.name + " Won The Game!";
            resultScore.text = "P1: 2                      P2: 0";
        }

        else if (scoreP1 < scoreP2) // Player 2 kazanır
        {
            resultText.text = p2.name + " Won The Game!";
            resultScore.text = "P1: 0                      P2: 2";
        }
        else if (scoreP1 == scoreP2) // Berabere
        {
            resultText.text = "Draw!";
            resultScore.text = "P1: 1                      P2: 1";
        }
        
    }
}
