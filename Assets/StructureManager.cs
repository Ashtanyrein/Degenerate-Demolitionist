using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureManager : MonoBehaviour
{
    public float max = 0.0f;
    public bool shouldExplode = false;
    public GameObject current;
    void Start()
    {
        //winHandler = GameObject.Find("WinLossHandler").WinRenderer.GetComponent<int>(); SHOULD WORK. DOESN'T. IDK WHY
    }
    void Update()
    {
        //update object positions and height

    }
}


