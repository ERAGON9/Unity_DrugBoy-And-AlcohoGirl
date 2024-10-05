using CanvasManagers;
using UnityEngine;

namespace GameLogic
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("Properties")]
        [SerializeField] private GameObject m_CanvasLevelFinishedObject;
        [SerializeField] private DrugBoy m_DrugBoy;
        [SerializeField] private AlcohoGirl m_AlcohoGirl;
    
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
            if (m_DrugBoy.IsFinished && m_AlcohoGirl.IsFinished && !m_IsLevelAlreadyFinish)
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
            CanvasDuringGame.Instance.RunTimer = false;
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
}