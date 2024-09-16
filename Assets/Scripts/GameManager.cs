using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public Text scoreText;
    private int score = 0;
    public bool drugBoyInFinish = false;
    public bool alcohoGirlInFinish = false;

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
        // scoreText.text = score.ToString();
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