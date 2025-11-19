using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToScene : MonoBehaviour
{
    public string destinationScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SwitchScene()
    {
        Debug.Log($"I AM HERE AND I AM SWITCHING TO {destinationScene}");
        SceneManager.LoadScene(destinationScene);
    }
}
