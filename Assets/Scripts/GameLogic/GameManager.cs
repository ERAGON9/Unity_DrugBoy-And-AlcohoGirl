using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject m_CanvasLevelFinishedObject;
    public bool DrugBoyInFinish = false;
    public bool AlcohoGirlInFinish = false;
    
    private int m_CurrentScore = 0;
    private bool m_IsAlreadyWon = false;
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
        if (AlcohoGirlInFinish && DrugBoyInFinish && !m_IsAlreadyWon)
        {
            if (isCurrentScoreEqualMaxScore())
            {
                m_IsAlreadyWon = true;
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
        Debug.Log("You win!"); // Added for debugging purposes
        
        CanvasDuringGame.Instance.RunTimer = false;
        //TODO: Stop players movement
        activateCanvasLevelFinished();
        string currentTime = CanvasDuringGame.Instance.CurrentTimeText.text;
        CanvasLevelFinished.Instance.UpdateHighScore(currentTime);
    }
    
    private void activateCanvasLevelFinished()
    {
        m_CanvasLevelFinishedObject.SetActive(true);
        CanvasLevelFinished.Instance.Initialize();
    }
}