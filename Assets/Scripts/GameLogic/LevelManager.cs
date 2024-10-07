using UnityEngine;

namespace GameLogic
{
    public class LevelManager : MonoBehaviour
    {
        [Header("Level Settings")]
        [SerializeField] private Vector2 m_DrugBoyInitialPosition;
        [SerializeField] private Vector2 m_AlcohoGirlInitialPosition;
        [SerializeField] private int m_MaxScore;
    
        private void Awake()
        {
            updatePlayersInitialPosition();
            updateMaxScoreForLevel();
        }

        private void updatePlayersInitialPosition()
        {
            GameManager.Instance.DrugBoyInitialPosition = m_DrugBoyInitialPosition;
            GameManager.Instance.AlcohoGirlInitialPosition = m_AlcohoGirlInitialPosition;
        }
        
        private void updateMaxScoreForLevel()
        {
            GameManager.Instance.MaxLevelScore = m_MaxScore;
        }
    }
}