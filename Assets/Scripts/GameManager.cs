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
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

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
        if (alcohoGirlInFinish && drugBoyInFinish)
        {
            if (isCurrentScoreEqualMaxScore())
            {
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