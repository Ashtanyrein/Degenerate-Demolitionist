using UnityEngine;
using System.Collections;

public class StructureDetector : MonoBehaviour
{
    public GameObject WinTextObject;
    public GameObject WinPanel;
    public GameObject LossPanel;
    public GameObject PedLossPanel;
    public GameObject PedestrianLossTextObject;
    public GameObject FailureLossTextObject;
    public GameObject RestartButton;
    public StructureManager Structure;
    public Vector2 DetectionAreaSize = new Vector2(10f, 10f);
    public LayerMask StructureLayer;
    public int pedestrianHits = 0;
    public void incrementPedoHits()
    {
        pedestrianHits += 1;
    }
    private void Start()
    {
        // Set the WinTextObject to inactive at the start
        WinTextObject.SetActive(false);
        PedestrianLossTextObject.SetActive(false);
        FailureLossTextObject.SetActive(false);
    }

    private void Update()
    {
        if (Structure.shouldExplode)
        {
            StartCoroutine(DetermineWinLoss());
        }
    }

    private bool IsStructureInside()
    {
        // Calculate the bottom-left and top-right corners of the detection area
        Vector2 bottomLeft = (Vector2)transform.position - DetectionAreaSize / 2f;
        Vector2 topRight = (Vector2)transform.position + DetectionAreaSize / 2f;

        // Perform a box cast to check for structures within the detection area
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, DetectionAreaSize, 0f, Vector2.zero, 0f, StructureLayer);

        // Return true if the box cast hits any collider on the structure layer
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        // Calculate the bottom-left and top-right corners of the detection area
        Vector2 bottomLeft = (Vector2)transform.position - DetectionAreaSize / 2f;
        Vector2 topRight = (Vector2)transform.position + DetectionAreaSize / 2f;

        // Draw the detection area outline
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, DetectionAreaSize);
    }
    private IEnumerator DetermineWinLoss()
    {
        yield return new WaitForSeconds(3.0f);

        // Check if there are any structures inside the detection area
        if (IsStructureInside() && (pedestrianHits <= 3))
        {
            // Structures still exist inside the area
            // The user hasn't won yet
            Debug.Log("Structures remaining. Keep destroying!");

            //FailureLossTextObject.SetActive(true);
            //RestartButton.SetActive(true);
            LossPanel.SetActive(true);
        }

        else
        {
            if ((pedestrianHits > 3))//if more than 3 pedestrian hits have occured then no win
            {
                //PedestrianLossTextObject.SetActive(true);
                //RestartButton.SetActive(true);
                PedLossPanel.SetActive(true);
            }
            // No structures inside the area
            // The user has won the game

            // Set the WinTextObject to active
            else if (!IsStructureInside() && (pedestrianHits <= 3))
            {
                //WinTextObject.SetActive(true);
                WinPanel.SetActive(true);
            }
        }
    }
}