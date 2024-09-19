using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    private int m_CurrentScore = 0;
    public bool DrugBoyInFinish = false;
    public bool AlcohoGirlInFinish = false;
    
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

    private bool isCurrentScoreEqualMaxScore()
    {
        return m_CurrentScore == MaxLevelScore;
    }
    
    public void CheckWin()
    {
        if (AlcohoGirlInFinish && DrugBoyInFinish)
        {
            if (isCurrentScoreEqualMaxScore())
            {
                CanvasDuringGame.Instance.SetInActiveLootInfoMsg();
                handleWin();
            }
            else
            {
                CanvasDuringGame.Instance.SetActiveLootInfoMsg();
            }
        }
    }
    
    private void handleWin()
    {
        Debug.Log("You win!");
        CanvasDuringGame.Instance.RunTimer = false;
        
        
    }
}