using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureManager : MonoBehaviour
{
    public float height = -10.0f;
    public bool shouldExplode = false;
    public bool won;
    public GameObject current;
    
    void Start()
    {
        won = false;
    }
    void Update()
    {
        //update object positions and height
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            current = this.gameObject.transform.GetChild(i).gameObject;
            if (current.transform.position.y >= height)
            {
                height = current.transform.position.y;
            }
        }

        if (height <= -1.0f)//-1.0 is arbitrary
        {
            won = true;//can be used to implement win state
        }

        height = -10.0f;
    }
}

