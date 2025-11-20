using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.IO;

namespace Appathon
{
    public class VideoWatcher : MonoBehaviour
    {
        public InputActionReference button;
        public VideoPlayer player;
        // Start is called once before the first execution of Update after the MonoBehaviour is created

        private bool isPrepared = false;
        void Start()
        {
            button.action.Enable();

            string videoPath = Path.Combine(Application.streamingAssetsPath, "intro.mp4");

            player.url = videoPath;

            player.prepareCompleted += OnVideoPrepared;
            player.Prepare();
        }

        private void OnVideoPrepared(VideoPlayer vp)
        {
            isPrepared = true;
            player.Play();
        }

        // Update is called once per frame

        void Update() {
            if (!isPrepared) return;

            // Debug.Log($"Button A: {button.action.triggered}");
            // Switch to main if the video stops playing or they press the skip button
            if (player.time >= player.length - 0.1 || button.action.triggered)
            {
                Debug.Log($"Button A: {button.action.triggered}");
                SceneManager.LoadScene("Main");
            }} } }