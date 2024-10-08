using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CanvasManagers
{
    public class CanvasMainMenu : MonoBehaviour
    {
        public const string k_LevelPlaylKey = "LevelToPlay";
        public const string k_HighestUnlockedLevelKey = "HighestUnlockedLevel";
        public const int k_HighestAvailableLevel = 3;
        
        [Header("Levels Menu")]
        [SerializeField] private List<Button> m_LevelsButtons;
        
        
        private void Awake()
        {
            //clearHighestUnlockedLevel(); // For testing purposes
            int highestUnlockedLevel = PlayerPrefs.GetInt(k_HighestUnlockedLevelKey, 1);
            setInteractebaleButtons(highestUnlockedLevel);
        }
        
        private void clearHighestUnlockedLevel() // For testing purposes
        {
            PlayerPrefs.DeleteKey(k_HighestUnlockedLevelKey);
        }
        
        private void setInteractebaleButtons(int i_HighestUnlockedLevel)
        {
            for (int i = 0; i < m_LevelsButtons.Count; i++)
            {
                m_LevelsButtons[i].interactable = i < i_HighestUnlockedLevel;
            }
        }
        
        public void PlayLevel(int i_LevelNumber)
        {
            PlayerPrefs.SetInt(k_LevelPlaylKey, i_LevelNumber);
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameScene");
        }
        
        public void QuitGame()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}