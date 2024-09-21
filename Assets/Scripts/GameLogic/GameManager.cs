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
    private bool m_IsLevelAlreadyFinish = false;
    public int MaxLevelScore { get; set; }
    

    public void AddPoints(int i_Points)
    {
        m_CurrentScore += i_Points;
        Debug.Log("Score: " + m_CurrentScore.ToString()); // Added for debugging purposes
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
    
    public void CheckLevelFinish()
    {
        if (AlcohoGirlInFinish && DrugBoyInFinish && !m_IsLevelAlreadyFinish)
        {
            if (isCurrentScoreEqualMaxScore())
            {
                m_IsLevelAlreadyFinish = true;
                CanvasDuringGame.Instance.SetInActiveLootInfoMsg();
                handleLevelFinish();
            }
            else
            {
                CanvasDuringGame.Instance.SetActiveLootInfoMsg();
            }
        }
    }
    
    private void handleLevelFinish()
    {
        Debug.Log("You win!"); // Added for debugging purposes
        
        CanvasDuringGame.Instance.RunTimer = false;
        //TODO: Stop players movement
        stopPlayersMovement();
        activateCanvasLevelFinished();
        string currentTime = CanvasDuringGame.Instance.CurrentTimeText.text;
        CanvasLevelFinished.Instance.UpdateHighScore(currentTime);
    }

    private void stopPlayersMovement()
    {
        DrugBoyController.Instance.CharacterPaused = true;
        AlcohoGirlController.Instance.CharacterPaused = true;
    }

    private void activateCanvasLevelFinished()
    {
        m_CanvasLevelFinishedObject.SetActive(true);
        CanvasLevelFinished.Instance.Initialize();
    }
}