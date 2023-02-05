using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject story;
    public float waitTime = 3f;

    public void StartButton()
    {
        Instruction.SetActive(true);
        story.SetActive(true);

        StartCoroutine(LoadGame());
    }


    public void QuitButton()
    {
        Application.Quit();
    }

    private IEnumerator LoadGame()
    {
        WaitForSeconds waiting = new(waitTime);
        yield return waiting;
        SceneManager.LoadScene("Game");
    }
}