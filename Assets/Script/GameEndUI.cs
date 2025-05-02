using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndUI : MonoBehaviour
{
    // Called by Restart Button
    public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    // Called by Quit Button
    public void QuitGame()
    {
        Debug.Log("QuitGame called");

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in editor
        #else
        Application.Quit(); // Quit build
        #endif
    }
}
