using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public Canvas gameCanvas;      
    public Canvas pauseCanvas;
    [SerializeField] private AudioSource music;
    private bool isPaused = false;

    void Start()
    {
        
        pauseCanvas.gameObject.SetActive(false);
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            
            ResumeGame();
        }
        else
        {
          
            PauseGame();
        }
    }

    private void PauseGame()
    {
      
        gameCanvas.gameObject.SetActive(false);

        
        pauseCanvas.gameObject.SetActive(true);

      
        Time.timeScale = 0f;
        music.pitch = 0f;
        
        isPaused = true;
    }

    private void ResumeGame()
    {
        
        gameCanvas.gameObject.SetActive(true);

        
        pauseCanvas.gameObject.SetActive(false);

        
        Time.timeScale = 1f;
        music.pitch = 1f;

       
        isPaused = false;
    }
}
