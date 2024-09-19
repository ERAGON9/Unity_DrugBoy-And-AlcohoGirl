using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasDuringGame : Singleton<CanvasDuringGame>
{
    private const string k_MaxScorePreview = "Max Score";
    
    [SerializeField] private TextMeshProUGUI m_CurrentScoreText;
    [SerializeField] private TextMeshProUGUI m_CurrentTimeText;
    
    
    public void UpdateCurrentScore(int i_CurrentScore)
    {
        m_CurrentScoreText.text = i_CurrentScore.ToString();
    }

    public void UpdateCurrentScoreToMax()
    {
        m_CurrentScoreText.text = k_MaxScorePreview;
    }
    
    public void UpdateCurrentTime(int i_CurrentTime)
    {
        m_CurrentTimeText.text = i_CurrentTime.ToString();
    }
}
