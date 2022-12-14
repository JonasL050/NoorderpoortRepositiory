using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int Player1Score = 0;
    public int Player2Score = 0;
    public Text player1;
    public Text player2;
    void Update()
    {
        if (Player1Score == 5)
        {
            SceneManager.LoadScene("Main Menu");
        }


        if (Player2Score == 5)
        {
            SceneManager.LoadScene("Main Menu");
        }

    }

    public void AddP1Score()
    {
        Player1Score++;
        player1.text = Player1Score.ToString();
    }

    public void AddP2Score()
    {
        Player2Score++;
        player2.text = Player2Score.ToString();
    }

}