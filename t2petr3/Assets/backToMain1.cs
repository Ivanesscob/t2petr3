using UnityEngine;
using UnityEngine.SceneManagement;

public class backToMain1 : MonoBehaviour
{
    public void back()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex = 0);
    }
}
