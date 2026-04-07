using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("nivel 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}