using UnityEngine;

namespace GameLogic
{
    public class LevelManager : MonoBehaviour
    {
        [Header("Level Settings")]
        [SerializeField] private int m_MaxScore;
    
    
        void Start()
        {
            GameManager.Instance.MaxLevelScore = m_MaxScore;
        }
    }
}