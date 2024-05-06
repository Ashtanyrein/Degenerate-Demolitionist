using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneCompletionToggler : MonoBehaviour
{
    // Start is called before the first frame update
    public int scenenumber = 0;
    public void SceneDone()
    {
         if (sceneCompletionManager.Instance != null)
        {
            if (scenenumber == 0)
            sceneCompletionManager.Instance.Scene1Done();
        if (scenenumber == 1)
sceneCompletionManager.Instance.Scene2Done();
        if (scenenumber == 2)
        sceneCompletionManager.Instance.Scene3Done();
        }
    }
}
