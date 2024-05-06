
using UnityEngine;
using UnityEngine.SceneManagement;

public class rockbrainscene2change : MonoBehaviour
{
    // Method to change to the specified scene
    public void ChangeScene()
    {
        SceneManager.LoadScene("level2");
    }
}
