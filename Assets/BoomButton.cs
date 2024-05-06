using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomButton : MonoBehaviour
{
    private bool buttonPressed = false;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GetComponentInParent<GameManager>();
    }

    
    public void OnButtonClick()
    {
        if (gameManager.IsItemPurchased())
        {
            if (!buttonPressed)
            {
                Debug.Log("Boom button pressed");
                buttonPressed = true;
                gameManager.TriggerExplosives();
            }
        }

        else Debug.Log("You need to purchase an item first");
    }

}
