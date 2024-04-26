using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureManager : MonoBehaviour
{
    public float height = 0.0f;
    public float max = 0.0f;
    public bool shouldExplode = false;
    public int winState;
    public GameObject current;
    public GameObject WinHandler;
    void Start()
    {
        //winHandler = GameObject.Find("WinLossHandler").WinRenderer.GetComponent<int>(); SHOULD WORK. DOESN'T. IDK WHY
    }
    void Update()
    {
        //update object positions and height
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            current = this.gameObject.transform.GetChild(i).gameObject;
            if (current.transform.position.y >= max)
            {
                max = current.transform.position.y;
            }
        }

        height = max;

        if (height <= -1.0f)//-1.0 is arbitrary
        {
            winState = 1;
        }
    }
}

