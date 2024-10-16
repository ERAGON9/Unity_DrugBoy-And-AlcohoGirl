using GameLogic;
using TMPro;
using UnityEngine;

namespace CanvasManagers
{
    public class CanvasDuringGame : Singleton<CanvasDuringGame>
    {
        private const string k_MaxScorePreview = "Max Score";
    
        [Header("Canvas During Game Settings")]
        [SerializeField] private TextMeshProUGUI m_CurrentScoreText;
        [SerializeField] private TextMeshProUGUI m_CurrentTimeText;
        [SerializeField] private TextMeshProUGUI m_LootInfoMsgText;
        
        public TextMeshProUGUI CurrentTimeText => m_CurrentTimeText;
        public bool RunTimer { get; set; } = true;
        
        private float m_ElapsedTime;
        
        
        private void Update()
        {
            if (RunTimer)
            {
                updateCurrentTime();
            }
        }
        
        private void updateCurrentTime()
        {
            m_ElapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(m_ElapsedTime / 60);
            int seconds = Mathf.FloorToInt(m_ElapsedTime % 60);
            m_CurrentTimeText.text = $"{minutes:00}:{seconds:00}";
        }
        
        public void UpdateCurrentScore(int i_CurrentScore)
        {
            m_CurrentScoreText.text = i_CurrentScore.ToString();
        }
        
        public void UpdateCurrentScoreToMax()
        {
            m_CurrentScoreText.text = k_MaxScorePreview;
        }
        
        public void SetActiveLootInfoMsg()
        {
            m_LootInfoMsgText.gameObject.SetActive(true);
        }
        
        public void SetInActiveLootInfoMsg()
        {
            m_LootInfoMsgText.gameObject.SetActive(false);
        }
    }
}