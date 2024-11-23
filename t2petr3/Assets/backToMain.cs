using UnityEngine;
using UnityEngine.SceneManagement;

public class backToMain : MonoBehaviour
{
    public void back()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex - 1);
    }
}
