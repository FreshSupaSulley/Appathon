using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class FNAK : MonoBehaviour
{
    public float totalSeconds = 30f;
    private float startTime;
    // long startTime = Time.time;

    public TMP_Text countdownText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // If time is over
        // unity.switchScene(gameOverScene)

        float elapsed_time = Time.time - startTime;
        float remaining_time = totalSeconds - elapsed_time;


        int minutes = Mathf.FloorToInt(remaining_time / 60f);

        int seconds = Mathf.FloorToInt(remaining_time % 60f);


        countdownText.text = $"{minutes:00}:{seconds:00}";

        if (remaining_time < 0)
        {
            //SceneManager.LoadScene("SceneName or Path")
        }

    }
}
