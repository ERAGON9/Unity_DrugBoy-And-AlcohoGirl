using UnityEngine;
using UnityEngine.SceneManagement;

namespace CanvasManagers
{
    public class CanvasMainMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene("GameScene");
        }
    
        public void QuitGame()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}