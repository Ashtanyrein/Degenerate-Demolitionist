using UnityEngine;

public class AnimatorHingeBalanceDisabler : MonoBehaviour
{
    public Rigidbody2D rigidbody1;
    public Rigidbody2D rigidbody2;

    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to the same GameObject
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the GameObject.");
        }
    }

    // Function to disable the Animator, the useLimits of all HingeJoint2D in child components,
    // disable the "Balance" script, and set the weight of two rigidbodies.
    public void DisableAllAndSetWeights()
    {
        // Disable the Animator
        if (animator != null)
        {
            animator.enabled = false;
            Debug.Log("Animator disabled.");
        }
        else
        {
            Debug.LogError("Animator component not found on the GameObject.");
        }

        balance balanceScript = GetComponentInChildren<balance>();

        if (balanceScript != null)
        {
            balanceScript.enabled = false;
            Debug.Log("Balance script disabled.");
        }
        else
        {
            Debug.LogError("Balance script not found in child objects.");
        }    // Set the mass of the provided rigidbodies to one
        if (rigidbody1 != null)
        {
            rigidbody1.mass = 1;
            Debug.Log($"Mass of Rigidbody1 set to 1.");
        }
        else
        {
            Debug.LogError("Rigidbody1 not set.");
        }

        if (rigidbody2 != null)
        {
            rigidbody2.mass = 1;
            Debug.Log($"Mass of Rigidbody2 set to 1.");
        }
        else
        {
            Debug.LogError("Rigidbody2 not set.");
        }
    }
}