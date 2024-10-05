using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasLevelFinished : Singleton<CanvasLevelFinished>
{
    private const string k_DefaultScore = "XX:XX";
    private const string k_Score1Key = "Score1Text";
    private const string k_Score2Key = "Score2Text";
    private const string k_Score3Key = "Score3Text";
    
    [Header("Main Banner")]
    [SerializeField] private TextMeshProUGUI m_MainBannerText;
    
    [Header("Score Texts")]
    [SerializeField] private TextMeshProUGUI m_Score1Text;
    [SerializeField] private TextMeshProUGUI m_Score2Text;
    [SerializeField] private TextMeshProUGUI m_Score3Text;
    
    private string m_Score1;
    private string m_Score2;
    private string m_Score3;

    public void Initialize()
    {
        //clearHighScoreData(); // For testing purposes
        getHighScore();
        setHighScoreUI(m_Score1, m_Score2, m_Score3);
    }

    private void clearHighScoreData() // For testing purposes
    {
        PlayerPrefs.DeleteKey(k_Score1Key);
        PlayerPrefs.DeleteKey(k_Score2Key);
        PlayerPrefs.DeleteKey(k_Score3Key);
    }

    private void getHighScore()
    {
        m_Score1 = PlayerPrefs.GetString(k_Score1Key, k_DefaultScore);
        m_Score2 = PlayerPrefs.GetString(k_Score2Key, k_DefaultScore);
        m_Score3 = PlayerPrefs.GetString(k_Score3Key, k_DefaultScore);
    }

    private void setHighScoreUI(string i_Score1, string i_Score2, string i_Score3)
    {
        m_Score1Text.text = i_Score1;
        m_Score2Text.text = i_Score2;
        m_Score3Text.text = i_Score3;
    }

    public void UpdateHighScore(string i_CurrentTime)
    {
        if (isNewHighScore(i_CurrentTime))
        {
            m_MainBannerText.text = "NEW HIGH SCORE!";
            updateHighScore(i_CurrentTime);
        }
        else
        {
            m_MainBannerText.text = "NOT SPEED ENOUGH!";
        }
    }

    private bool isNewHighScore(string i_CurrentTime)
    {
        return m_Score3.CompareTo(k_DefaultScore) == 0 || i_CurrentTime.CompareTo(m_Score3) < 0;
    }

    private void updateHighScore(string i_CurrentTime)
    {
        if (m_Score1.CompareTo(k_DefaultScore) == 0 || i_CurrentTime.CompareTo(m_Score1) < 0)
        {
            m_Score3 = m_Score2;
            m_Score2 = m_Score1;
            m_Score1 = i_CurrentTime;
        }
        else if (m_Score2.CompareTo(k_DefaultScore) == 0 || i_CurrentTime.CompareTo(m_Score2) < 0)
        {
            m_Score3 = m_Score2;
            m_Score2 = i_CurrentTime;
        }
        else if (m_Score3.CompareTo(k_DefaultScore) == 0 || i_CurrentTime.CompareTo(m_Score3) < 0)
        {
            m_Score3 = i_CurrentTime;
        }

        setHighScoreUI(m_Score1, m_Score2, m_Score3);
        saveHighScore();
    }

    private void saveHighScore()
    {
        PlayerPrefs.SetString(k_Score1Key, m_Score1);
        PlayerPrefs.SetString(k_Score2Key, m_Score2);
        PlayerPrefs.SetString(k_Score3Key, m_Score3);
        PlayerPrefs.Save();
    }
    
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}