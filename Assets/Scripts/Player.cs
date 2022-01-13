using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;

    public GameManager gameManager;

    public Text winnerText;
    public Text p1HealthNumber;
    public Text p2HealthNumber;

    public float y_position;
    public int can = 3;
    public int damage = 20;
    public int maxHealth = 100;
    public int currentHealth;

    private int scoreP1 = 0;
    private int scoreP2 = 0;

    public static bool GameHasEnded = false;

    public HealthBar healthBar;

    void Start()
    {
        Player p1 = player1.GetComponent<Player>();
        Player p2 = player2.GetComponent<Player>();

        if (PlayerPrefs.GetInt("isContinued") != 1)
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
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

    void Update()
    {
        Player p1 = player1.GetComponent<Player>();
        Player p2 = player2.GetComponent<Player>();

        p1.y_position = p1.transform.position.y;
        p2.y_position = p2.transform.position.y;
        
        if(p1.y_position < -9.0f)
        {
            
            gameManager.GameEnded();
            winnerText.text = player2.name + " Won the Game!";
            GameHasEnded = true;
        }
        if(p2.y_position < -9.0f)
        {
            
            gameManager.GameEnded();
            winnerText.text = player1.name + " Won the Game!";
            GameHasEnded = true;
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        Player p1 = player1.GetComponent<Player>();
        Player p2 = player2.GetComponent<Player>();

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
                if(p1.can == 0)
                {
                    Destroy(p1.gameObject);
                    //Debug.Log("player2 kazandı");

                    gameManager.GameEnded();
                    winnerText.text = player2.name + " Won the Game!";
                    GameHasEnded = true;
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
                if(p2.can == 0)
                {
                    Destroy(p2.gameObject);
                    //Debug.Log("player1 kazandı");

                    gameManager.GameEnded();
                    winnerText.text = player1.name + " Won the Game!";
                    GameHasEnded = true;
                }
            }
        }
    }
}
