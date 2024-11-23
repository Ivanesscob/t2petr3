using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void LoadNextScene()
    {
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadLevel(int level)
    {
        PlayerPrefs.SetInt("lvl", level);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
