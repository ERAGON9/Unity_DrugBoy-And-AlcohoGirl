using UnityEngine;
using UnityEngine.SceneManagement;

namespace CanvasManagers
{
    public class CanvasMainMenu : MonoBehaviour
    {
        private const string k_LevePlaylKey = "LevelToPlay";
        
        public void PlayLevel(int i_LevelNumber)
        {
            PlayerPrefs.SetInt(k_LevePlaylKey, i_LevelNumber);
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