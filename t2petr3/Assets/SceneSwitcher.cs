using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    
    public bool isCharacterSelected = false;

    public void LoadNextScene()
    {
        if (!isCharacterSelected)
        {
            Debug.Log("�������� �� ������! ����� �� ����� �����������.");
            return;
        }

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadLevel(int level)
    {
        

        PlayerPrefs.SetInt("lvl", level);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
