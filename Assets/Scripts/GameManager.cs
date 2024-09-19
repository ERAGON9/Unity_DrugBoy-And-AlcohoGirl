using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    private int m_CurrentScore = 0;
    public bool drugBoyInFinish = false;
    public bool alcohoGirlInFinish = false;
    
    public int MaxLevelScore { get; set; }
    

    public void AddPoints(int i_Points)
    {
        m_CurrentScore += i_Points;
        Debug.Log("Score: " + m_CurrentScore.ToString());
        updateScoreUI();
    }

    private void updateScoreUI()
    {
        if (!isCurrentScoreEqualMaxScore())
        {
            CanvasDuringGame.Instance.UpdateCurrentScore(m_CurrentScore);
        }
        else
        {
            CanvasDuringGame.Instance.UpdateCurrentScoreToMax();
        }
    }

    public void CheckWin()
    {
        if (alcohoGirlInFinish && drugBoyInFinish && isCurrentScoreEqualMaxScore())
        {
            handleWin();
        }
    }
    
    private bool isCurrentScoreEqualMaxScore()
    {
        return m_CurrentScore == MaxLevelScore;
    }
    
    private void handleWin()
    {
        Debug.Log("You win!");
    }
}