using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Minigame");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
