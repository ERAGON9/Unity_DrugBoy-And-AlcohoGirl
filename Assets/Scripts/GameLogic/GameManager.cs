using System;
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
        
        public int MaxLevelScore { get; set; }
        public Vector2 DrugBoyInitialPosition { get; set; }
        public Vector2 AlcohoGirlInitialPosition { get; set; }
        
        private int m_CurrentScore = 0;
        private bool m_IsLevelAlreadyFinish = false;
        private LevelManager m_CurrentLevelManager;

        private void Awake()
        {
            instantiateLevel();
        }

        private void instantiateLevel()
        {
            int levelNumberToPlay = PlayerPrefs.GetInt(CanvasMainMenu.k_LevelPlaylKey);
            
            if (levelNumberToPlay < 1 || levelNumberToPlay > CanvasMainMenu.k_HighestAvailableLevel) // Debugging purposes
            {
                Debug.LogError($"Level number: {levelNumberToPlay}, isn't legal level number!");
            }

            GameObject currentLevel = Instantiate(LevelsManagement.Instance.LevelsCollection[--levelNumberToPlay], Vector3.zero, Quaternion.identity);
            m_CurrentLevelManager = currentLevel.GetComponent<LevelManager>();
        }

        private void Start()
        {
            MoveDrugBoyToInitialPosition();
            MoveAlcohoGirlToInitialPosition();
        }
        
        public void MoveDrugBoyToInitialPosition()
        {
            m_DrugBoy.transform.position = DrugBoyInitialPosition;
        }
        
        public void MoveAlcohoGirlToInitialPosition()
        {
            m_AlcohoGirl.transform.position = AlcohoGirlInitialPosition;
        }
        
        public void AddPoints(int i_Points)
        {
            m_CurrentScore += i_Points;
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
            updateLevelHighScore(currentTime);
            updateHighestUnlockedLevel();
        }
        
        private void stopPlayersMovement()
        {
            DrugBoyController.Instance.CharacterPaused = true;
            AlcohoGirlController.Instance.CharacterPaused = true;
        }

        private void activateCanvasLevelFinished()
        {
            m_CanvasLevelFinishedObject.SetActive(true);
            CanvasLevelFinished.Instance.SetHighScoresUI(m_CurrentLevelManager.HighScore1,
                m_CurrentLevelManager.HighScore2, m_CurrentLevelManager.HighScore3);
        }
        
        private void updateLevelHighScore(string i_CurrentTime)
        {
            if (m_CurrentLevelManager.IsNewHighScore(i_CurrentTime))
            {
                m_CurrentLevelManager.UpdateHighScore(i_CurrentTime);
                CanvasLevelFinished.Instance.NewHighScoreUI(m_CurrentLevelManager.HighScore1,
                    m_CurrentLevelManager.HighScore2, m_CurrentLevelManager.HighScore3);
            }
            else
            {
                CanvasLevelFinished.Instance.NotSpeedEnoughUI();
            }
        }
        
        private void updateHighestUnlockedLevel()
        {
            int currentLevel = PlayerPrefs.GetInt(CanvasMainMenu.k_LevelPlaylKey);
            int highestUnlockedLevel = PlayerPrefs.GetInt(CanvasMainMenu.k_HighestUnlockedLevelKey, 1);
            
            if (currentLevel == highestUnlockedLevel && currentLevel < CanvasMainMenu.k_HighestAvailableLevel)
            {
                PlayerPrefs.SetInt(CanvasMainMenu.k_HighestUnlockedLevelKey, ++highestUnlockedLevel);
                PlayerPrefs.Save();
            }
        }
    }
}