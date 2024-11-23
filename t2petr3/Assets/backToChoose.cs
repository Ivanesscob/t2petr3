using UnityEngine;
using UnityEngine.SceneManagement;

public class backToChoose : MonoBehaviour
{
    public void Click()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex = 1);
    }
}
