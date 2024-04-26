using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLossScript : MonoBehaviour
{
    public int winState = 2;//0 for loss, 1 for win, 2 for uncertain
    public GameObject WinTextObject;
    public TextMesh WinText;
    public MeshRenderer WinRenderer;
    //public GameObject LossTextObject;
    //public TextMesh LossText;
    //public MeshRenderer LossRenderer
    // Start is called before the first frame update
    void Start()
    {
        WinTextObject = GameObject.Find("WinText");
        //WinText = WinTextObject.GetComponent<TextMesh>();THESE LINES DONT WORK. IDK WHY. WILL FIX.
        //WinRenderer = WinText.GetComponent<MeshRenderer>();
        WinRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(winState == 1)
        {
            WinRenderer.enabled = true;
        }
    }
}
