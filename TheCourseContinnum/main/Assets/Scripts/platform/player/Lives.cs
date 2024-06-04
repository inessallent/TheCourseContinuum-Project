using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    private static int playerLives1 = 2;
    private static int playerLives2 = 2;

    private GameObject player1;
    private GameObject player2;

    private AudioSource audioSource;
    private static int totalPlayers = 2;
    private static int playersOut = 0;


    void Start()
    {

        player1 = Controller.instance.boot1;
        player2 = Controller.instance.boot2;


        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void LoseLife(int playerID)
    {
        if (playerID == 1)
        {
            playerLives1 -= 1;
            livesPlayer1();
        }

        if (playerID == 2)
        {
            playerLives2 -= 1;
            livesPlayer2();
        }
        
    }

    public void livesPlayer1()
    {

        if (playerLives1 == 0)
        {

            Controller.EndGamePlayer1();
            playersOut++;


            if (playersOut == totalPlayers)
            {
                Controller.RestartGame();
            }
        }
    }

    public void livesPlayer2()
    {

        if (playerLives2 == 0)
        {

            Controller.EndGamePlayer2();
            playersOut++;


            if (playersOut == totalPlayers)
            {
                Controller.RestartGame();
            }
        }
    }

    public static void ResetPlayerCounters()
    {
        totalPlayers = 2;
        playersOut = 0;
        playerLives1 = 2;
        playerLives2 = 2;
    }
}