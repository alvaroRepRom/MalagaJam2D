using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject Instruction;

    public void StartButton()
    {
        Instruction.SetActive(true);
        StartCoroutine(LoadGame());
    }


    public void QuitButton()
    {
        Application.Quit();
    }

    private IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Game");
    }
}