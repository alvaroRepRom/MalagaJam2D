using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowInvocation : MonoBehaviour
{
    public GameObject tree;
    public GameObject dog;
    public GameObject cat;
    public GameObject goblin;

    public float timeToShow = 5f;
    public float maxNumOfPeople = 20;

    public ParticleSystem explosion;

    private void Start() => StartCoroutine(ShowInvocationA());

    private IEnumerator ShowInvocationA()
    {
        float timer = 0f;

        while (timer < timeToShow)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        explosion.Play();
        CalculateInvocaction();
    }

    private void CalculateInvocaction()
    {
        float percentaje = PlayerPrefs.GetInt("people") / maxNumOfPeople * 100;

        if (percentaje >= 90)
        {
            tree.SetActive(true);
        }
        else if (percentaje >= 70)
        {
            goblin.SetActive(true);
        }
        else if (percentaje >= 40)
        {
            cat.SetActive(true);
        }
        else if (percentaje > 0)
        {
            dog.SetActive(true);
        }

        PlayerPrefs.DeleteAll();
        StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        float timer = 0f;

        while (timer < 5f)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        AudioManager.Instance.CloseInstance();
        SceneManager.LoadScene("MainMenu");
    }
}
