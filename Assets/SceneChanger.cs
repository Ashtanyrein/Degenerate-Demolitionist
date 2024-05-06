using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Method to change to the specified scene
    public sceneCompletionManager scenes;
    public void Start()
    {
        scenes = GetComponentInParent<sceneCompletionManager>();
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene("Ash Scene");
    }
}
