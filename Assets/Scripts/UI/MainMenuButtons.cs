using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Game");
    }


    public void QuitButton()
    {
        Application.Quit();
    }
}