using UnityEngine;

namespace GameLogic
{
    public class LevelManager : MonoBehaviour
    {
        [Header("Level Settings")] 
        [SerializeField] private int m_LevelNumber;
        [SerializeField] private Vector2 m_DrugBoyInitialPosition;
        [SerializeField] private Vector2 m_AlcohoGirlInitialPosition;
        [SerializeField] private int m_MaximumScore;

        public string HighScore1 { get; private set; }
        public string HighScore2 { get; private set; }
        public string HighScore3 { get; private set; }

        private const string k_DefaultScore = "XX:XX";
        private string m_HighScore1Key;
        private string m_HighScore2Key;
        private string m_HighScore3Key;
        
        private void Awake()
        {
            updatePlayersInitialPosition();
            updateMaxScoreForLevel();
            fillHighScoreKeys();
            //clearLevelHighScoreData(); // For testing purposes
            fillHighScores();
        }

        private void updatePlayersInitialPosition()
        {
            GameManager.Instance.DrugBoyInitialPosition = m_DrugBoyInitialPosition;
            GameManager.Instance.AlcohoGirlInitialPosition = m_AlcohoGirlInitialPosition;
        }

        private void updateMaxScoreForLevel()
        {
            GameManager.Instance.MaxLevelScore = m_MaximumScore;
        }
        
        private void fillHighScoreKeys()
        {
            m_HighScore1Key = $"Level{m_LevelNumber}-Score1";
            m_HighScore2Key = $"Level{m_LevelNumber}-Score2";
            m_HighScore3Key = $"Level{m_LevelNumber}-Score3";
        }
        
        private void clearLevelHighScoreData() // For testing purposes
        {
            PlayerPrefs.DeleteKey(m_HighScore1Key);
            PlayerPrefs.DeleteKey(m_HighScore2Key);
            PlayerPrefs.DeleteKey(m_HighScore3Key);
        }
        
        private void fillHighScores()
        {
            HighScore1 = PlayerPrefs.GetString(m_HighScore1Key, k_DefaultScore);
            HighScore2 = PlayerPrefs.GetString(m_HighScore2Key, k_DefaultScore);
            HighScore3 = PlayerPrefs.GetString(m_HighScore3Key, k_DefaultScore);
        }
        
        public bool IsNewHighScore(string i_CurrentTime)
        {
            return HighScore3.CompareTo(k_DefaultScore) == 0 || i_CurrentTime.CompareTo(HighScore3) < 0;
        }

        public void UpdateHighScore(string i_CurrentTime)
        {
            if (HighScore1.CompareTo(k_DefaultScore) == 0 || i_CurrentTime.CompareTo(HighScore1) < 0)
            {
                HighScore3 = HighScore2;
                HighScore2 = HighScore1;
                HighScore1 = i_CurrentTime;
            }
            else if (HighScore2.CompareTo(k_DefaultScore) == 0 || i_CurrentTime.CompareTo(HighScore2) < 0)
            {
                HighScore3 = HighScore2;
                HighScore2 = i_CurrentTime;
            }
            else if (HighScore3.CompareTo(k_DefaultScore) == 0 || i_CurrentTime.CompareTo(HighScore3) < 0)
            {
                HighScore3 = i_CurrentTime;
            }
            
            saveHighScores();
        }

        private void saveHighScores()
        {
            PlayerPrefs.SetString(m_HighScore1Key, HighScore1);
            PlayerPrefs.SetString(m_HighScore2Key, HighScore2);
            PlayerPrefs.SetString(m_HighScore3Key, HighScore3);
            PlayerPrefs.Save();
        }
    }
}