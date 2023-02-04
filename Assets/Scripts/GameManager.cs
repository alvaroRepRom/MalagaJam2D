using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float aGameSeconds = 60f;
    public GameObject[] candles;

    private float timer = 0f;
    private float clockTimer = 0f;
    private int ticks = 0;
    private bool hasChangeMusic = false;

    private void Update()
    {
        timer += Time.deltaTime;
        clockTimer += Time.deltaTime;

        FireClock();
        ChangeMusic();
        ChangeScene();
    }

    private void FireClock()
    {
        float interval = aGameSeconds / 12;
        if (clockTimer >= interval)
        {
            clockTimer -= interval;
            candles[ticks].SetActive(true);
            ticks++;
        }
    }

    private void ChangeMusic()
    {
        if (!hasChangeMusic && timer >= aGameSeconds / 2)
        {
            AudioManager.Instance.ChangeMusic();
            hasChangeMusic = true;
        }
    }

    private void ChangeScene() 
    {
        if (timer >= aGameSeconds)
            SceneManager.LoadScene("Final"); 
    }
}