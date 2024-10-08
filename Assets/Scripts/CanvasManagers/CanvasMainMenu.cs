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
        
        [Header("Audio")] 
        [SerializeField] private AudioSource m_AudioSource;
        [SerializeField] private AudioClip m_EnergeticBackgroundClip;
        
        [Header("Levels Menu")]
        [SerializeField] private List<Button> m_LevelsButtons;
        
        
        private void Awake()
        {
            //clearHighestUnlockedLevel(); // For testing purposes
            int highestUnlockedLevel = PlayerPrefs.GetInt(k_HighestUnlockedLevelKey, 1);
            setInteractebaleButtons(highestUnlockedLevel);
            playBackgroundMusic();
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
        
        private void playBackgroundMusic()
        {
            m_AudioSource.clip = m_EnergeticBackgroundClip;
            m_AudioSource.loop = true;
            m_AudioSource.Play();
        }
        
        public void PlayLevel(int i_LevelNumber)
        {
            stopBackgroundMusic();
            PlayerPrefs.SetInt(k_LevelPlaylKey, i_LevelNumber);
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameScene");
        }

        private void stopBackgroundMusic()
        {
            m_AudioSource.Stop();
        }

        public void QuitGame()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}