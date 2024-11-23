using UnityEngine;
using UnityEngine.SceneManagement;

public class top : MonoBehaviour
{
    public void NextSence()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 3);
    }
   
}
