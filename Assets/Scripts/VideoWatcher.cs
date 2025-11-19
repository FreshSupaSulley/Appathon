using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace Appathon
{
    public class VideoWatcher : MonoBehaviour
    {
        public InputActionReference button;
        public VideoPlayer player;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            button.action.Enable();
        }

        // Update is called once per frame
        void Update()
        {
            // Debug.Log($"Button A: {button.action.triggered}");
            // Switch to main if the video stops playing or they press the skip button
            if(player.time >= player.length || button.action.triggered)
            {
                Debug.Log($"Button A: {button.action.triggered}");
                SceneManager.LoadScene("Main");
            }
        }
    }
}
