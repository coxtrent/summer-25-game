using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;
    bool isPaused = false;

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                if (isPaused)
                    Resume();
                else
                    Pause();
            }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

        public void RestartScene()
    {
        Time.timeScale = 1f; // Ensure time is running
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}