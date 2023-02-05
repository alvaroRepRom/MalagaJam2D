using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-100)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float aGameSeconds = 60f;
    public GameObject[] candles;
    public int peopleLeft = 12;
    public int peopleOnWaypoint = 8;
    public List<GameObject> waypoints;

    private float timer = 0f;
    private float clockTimer = 0f;
    private int ticks = 0;
    private bool hasChangeMusic = false;
    private bool hasEndGame = false;
    private bool isGameActive = false;

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

    public void InitManager()
    {
        timer = 0f;
        clockTimer = 0f;
        ticks = 0;
        hasChangeMusic = false;
        hasEndGame = false;
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

        if (hasChangeMusic && timer >= aGameSeconds * 0.9f)
        {
            AudioManager.Instance.ThirdSection();
        }
        if (hasChangeMusic && timer >= aGameSeconds * 0.75f)
        {
            AudioManager.Instance.SecondSection();
        }
    }

    private void ChangeScene() 
    {
        if (timer >= aGameSeconds)
        {
            hasEndGame = true;
            PlayerPrefs.SetInt("people", peopleLeft);
            PlayerPrefs.SetInt("languaje", peopleLeft);
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
    public void StartGame() => isGameActive = true;

    public bool IsgameActive
    {
        get => isGameActive;
        set => isGameActive = value;
    }
}