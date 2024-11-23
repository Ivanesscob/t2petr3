using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Флаг, указывающий, выбран ли персонаж
    public bool isCharacterSelected = false;

    public void LoadNextScene()
    {
        if (!isCharacterSelected)
        {
            Debug.Log("Персонаж не выбран! Сцена не будет переключена.");
            return; // Не переключаем сцену, если персонаж не выбран
        }

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadLevel(int level)
    {
        if (!isCharacterSelected)
        {
            Debug.Log("Персонаж не выбран! Сцена не будет переключена.");
            return; // Не переключаем сцену, если персонаж не выбран
        }

        PlayerPrefs.SetInt("lvl", level);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
