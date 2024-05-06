
using UnityEngine;
using UnityEngine.SceneManagement;

public class rockbrainscene2change : MonoBehaviour
{
    public sceneCompletionManager scenes;
    // Method to change to the specified scene
    public void Start()
    {
        scenes = GetComponentInParent<sceneCompletionManager>();
    }
    public void ChangeScene1()
    {
        SceneManager.LoadScene("newlvl1");
    }
    public void ChangeScene2()
    {
        if(scenes.Scene2Unlocked)
        {
            SceneManager.LoadScene("Ash Scene");
        }
    }
    public void ChangeScene3()
    {
        if(scenes.Scene3Unlocked)
        {
            SceneManager.LoadScene("level2");
        }
    }
    public void ChangeScene4()
    {
        if(scenes.Scene4Unlocked)
        {
            SceneManager.LoadScene("level4");
        }
    }
}
