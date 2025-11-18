using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class FNAK : MonoBehaviour

{
    //Objects that need to be detected that are attached
    private bool object1attached;

    public float totalSeconds = 30f;
    private float startTime;
    // long startTime = Time.time;

    public TMP_Text countdownText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startTime = Time.time;
        object1attached = false;
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
        //Will also need to check if all the objects are attached
        if (remaining_time < 0 || object1attached)
        {
            //SceneManager.LoadScene("SceneName or Path")
        }



    }

    public void SetAttached(bool attached)
    {
        object1attached = attached;
    }
}
