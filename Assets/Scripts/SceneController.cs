using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadHowToPlayScene()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void ExitApplication()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                 Application.Quit();
        #endif
    }
}
