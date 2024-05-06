using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Method to change to the specified scene
    public void ChangeScene()
    {
        SceneManager.LoadScene("Ash Scene");
    }
}
