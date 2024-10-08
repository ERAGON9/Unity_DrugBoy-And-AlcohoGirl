using GameLogic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CanvasManagers
{
    public class CanvasLevelFinished : Singleton<CanvasLevelFinished>
    {
        [Header("Main Banner")]
        [SerializeField] private TextMeshProUGUI m_MainBannerText;
    
        [Header("Scores Texts")]
        [SerializeField] private TextMeshProUGUI m_Score1Text;
        [SerializeField] private TextMeshProUGUI m_Score2Text;
        [SerializeField] private TextMeshProUGUI m_Score3Text;
        
        
        public void SetHighScoresUI(string i_Score1, string i_Score2, string i_Score3)
        {
            m_Score1Text.text = i_Score1;
            m_Score2Text.text = i_Score2;
            m_Score3Text.text = i_Score3;
        }

        public void NewHighScoreUI(string i_Score1, string i_Score2, string i_Score3)
        {
            m_MainBannerText.text = "NEW HIGH SCORE!";
            SetHighScoresUI(i_Score1, i_Score2, i_Score3);
        }
        
        public void NotSpeedEnoughUI()
        {
            m_MainBannerText.text = "NOT SPEED ENOUGH!";
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}