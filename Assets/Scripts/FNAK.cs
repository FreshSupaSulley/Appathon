using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.XR.CoreUtils;
using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using System.Collections;

public class FNAK : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    // THE tasks parent that holds the Interactables and Drop Zones as 2 children
    // It's expected that this layout stays the same in the editor
    public GameObject tasksGameObject;
    public GameObject[] decoyDropZones;
    // Appears in front of the Camera (statically)
    public TextMeshProUGUI todoText;
    // Array of things to clean / to do
    public string[] todoTexts;

    private List<GameObject> interactables = new();
    private List<GameObject> dropZones = new();

    public float totalSeconds = 30f;
    private float startTime;
    // long startTime = Time.time;
    public TMP_Text countdownText;

    private int lastTask = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startTime = Time.time;

        // Extract shit from tasks
        GameObjectUtils.GetChildGameObjects(tasksGameObject.GetNamedChild("Interactables"), interactables);
        GameObjectUtils.GetChildGameObjects(tasksGameObject.GetNamedChild("Drop Zones"), dropZones);

        // Set to the first task
        todoText.SetText(todoTexts[0]);
    }

    // Update is called once per frame
    void Update()
    {
        // Determine the current task and update the GUI text
        // This iteratively checks all tasks and finds the first one yet to be completed
        for (int i = 0; i < dropZones.Count; i++)
        {
            bool socketHasSelection = dropZones[i].GetComponent<XRSocketInteractor>().hasSelection;
            bool fakeSocketHasSelection = decoyDropZones[i]?.GetComponent<XRSocketInteractor>()?.hasSelection ?? false;

            // If this is the current task still left to do
            // If the correct socket isn't filled AND the fake one isn't filled either
            if (!socketHasSelection && !fakeSocketHasSelection)
            {
                // If we just switched to it
                if (i != lastTask)
                {
                    // In case it was still speaking, stop it
                    audioSource.Stop();
                    // Play the audio clip
                    audioSource.PlayOneShot(audioClips[i]);
                    lastTask = i;
                }

                // Update text
                todoText.SetText(todoTexts[i]);
                break;
            }
        }

        if (CheckWinState())
        {
            SceneManager.LoadScene("Win");
        }

        float elapsedTime = Time.time - startTime;
        float remainingTime = Mathf.Max(totalSeconds - elapsedTime, 0f);
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        countdownText.text = $"{minutes:00}:{seconds:00}";

        // Check if the time expired
        if (remainingTime <= 0 && CheckWinState() == false)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    private bool CheckWinState()
    {
        List<GameObject> sockets = new();
        // Check if all drop zones are filled with something
        for (int i = 0; i < dropZones.Count; i++)
        {
            var real = dropZones[i].GetComponent<XRSocketInteractor>();
            var fake = decoyDropZones[i]?.GetComponent<XRSocketInteractor>();

            // Abandon if all the sockets aren't filled yet
            if (!real.hasSelection && !(fake?.hasSelection ?? false))
                return false;

            // Null is picked up on below
            sockets.Add(real.hasSelection ? real.GetOldestInteractableSelected().transform.gameObject : null);
        }
        
        // Now check if they're filled with the correct object
        for (int i = 0; i < sockets.Count; i++)
        {
            var sample = sockets[i];

            // If the player fucked up which item goes where
            if (sample == null || !sample.name.Equals(interactables[i].name))
            {
                // You lost. Skip to the timeout
                // ... or we could just load the lose screen immediately
                startTime = Time.time - totalSeconds;
                return false;
            }
        }

        // We won
        return true;
    }
}
