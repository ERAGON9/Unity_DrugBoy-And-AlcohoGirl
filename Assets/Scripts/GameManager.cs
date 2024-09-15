using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text scoreText;
    private int score = 0;
    public bool drugBoyInFinish = false;
    public bool alcohoGirlInFinish = false;

    private void Awake()
    {
        // Ensure that there is only one instance of the GameManager (Singleton Pattern)
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to add points to the score
    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("Score: " + score.ToString());
        UpdateScoreUI();
    }

    // Update the score text on the UI
    private void UpdateScoreUI()
    {
        // scoreText.text = "Score: " + score.ToString();
    }


    public void CheckWin()
    {
        if (alcohoGirlInFinish && drugBoyInFinish)
        {
            Win();
        }
    }
    
    private void Win()
    {
        Debug.Log("You win!");
    }
}