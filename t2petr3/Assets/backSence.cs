using UnityEngine;
using UnityEngine.SceneManagement;

public class backSence : MonoBehaviour
{
    public void back()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex - 3);
    }
}
