using UnityEngine;

public class sceneCompletionManager : MonoBehaviour
{
    public static sceneCompletionManager Instance { get; private set; }

    public GameObject Scene2LockIcon;
    public GameObject Scene3LockIcon;
    public GameObject Scene4LockIcon;
    public bool Scene2Unlocked = false;
    public bool Scene3Unlocked = false;
    public bool Scene4Unlocked = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Scene2LockIcon.SetActive(!Scene2Unlocked);
        Scene3LockIcon.SetActive(!Scene3Unlocked);
        Scene4LockIcon.SetActive(!Scene4Unlocked);
    }

    public void Scene1Done()
    {
        Scene2LockIcon.SetActive(false);
        Scene2Unlocked = true;
    }

    public void Scene2Done()
    {
        Scene3LockIcon.SetActive(false);
        Scene3Unlocked = true;
    }

    public void Scene3Done()
    {
        Scene4LockIcon.SetActive(false);
        Scene4Unlocked = true;
    }
}
