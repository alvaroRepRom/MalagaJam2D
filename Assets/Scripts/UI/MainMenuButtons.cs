using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject story;
    public GameObject storyEnglish;
    public GameObject credits;
    public float waitTime = 3f;

    public void StartButton()
    {
        Instruction.SetActive(true);
        story.SetActive(true);
        storyEnglish.SetActive(true);
        credits.SetActive(false);

        StartCoroutine(LoadGame());
    }

    public void CreditsButton()
    {
        credits.SetActive(!credits.activeSelf);
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