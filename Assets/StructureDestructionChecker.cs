using UnityEngine;
using System.Collections;

public class StructureDetector : MonoBehaviour
{
    public GameObject WinTextObject;
    public GameObject PedestrianLossTextObject;
    public GameObject FailureLossTextObject;
    public StructureManager Structure;
    public Vector2 DetectionAreaSize = new Vector2(10f, 10f);
    public LayerMask StructureLayer;

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
        /*
        // Check if there are any structures inside the detection area
        if (IsStructureInside())
        {
            // Structures still exist inside the area
            // The user hasn't won yet
            Debug.Log("Structures remaining. Keep destroying!");
        }
        else
        {
            // No structures inside the area
            // The user has won the game
            Debug.Log("Congratulations! You have destroyed all structures.");

            // Set the WinTextObject to active
            // WinTextObject.SetActive(true);

            // Set the WinPanel to active
            WinPanel.SetActive(true);


            // Perform any desired actions when the user wins
            // For example, you can show a victory screen, update score, etc.
        }*/
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
        if (IsStructureInside())
        {
            // Structures still exist inside the area
            // The user hasn't won yet
            Debug.Log("Structures remaining. Keep destroying!");

            FailureLossTextObject.SetActive(true);
        }

        //else if (Pedestrian stuff)

        else
        {
            if (false)//place condition for excessive pedestrian damage here
            {
                PedestrianLossTextObject.SetActive(true);
            }
            // No structures inside the area
            // The user has won the game

            // Set the WinTextObject to active
            else
            {
                WinTextObject.SetActive(true);
            }

            // Perform any desired actions when the user wins
            // For example, you can show a victory screen, update score, etc.
        }
    }
}