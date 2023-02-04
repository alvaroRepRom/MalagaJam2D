using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float aGameSeconds = 60f;
    public GameObject[] candles;
    public int peopleLeft = 16;

    private float timer = 0f;
    private float clockTimer = 0f;
    private int ticks = 0;
    private bool hasChangeMusic = false;
    private bool hasEndGame = false;

    public Action onTimeComplete;

    private void Awake() => Instance = this;

    private void Update()
    {
        if (hasEndGame) return;

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
        {
            hasEndGame = true;
            PlayerPrefs.SetInt("people", peopleLeft);
            PlayerPrefs.Save();
            onTimeComplete?.Invoke();
            StartCoroutine(WaitToNextScene());
        }
    }

    private IEnumerator WaitToNextScene()
    {
        WaitForSeconds waitTime = new WaitForSeconds(5);
        yield return waitTime;
        SceneManager.LoadScene("Final");
    }

    public void NPCHasLeftRoom() => peopleLeft--;
}