using UnityEngine;
using UnityEngine;

public class AnimatorHingeBalanceDisabler : MonoBehaviour
{
    public Rigidbody2D rigidbody1;
    public Rigidbody2D rigidbody2;
    public HingeJoint2D hingeJoint1;
    public HingeJoint2D hingeJoint2;
    public HingeJoint2D hingeJoint3;
    public HingeJoint2D hingeJoint4;
    public HingeJoint2D hingeJoint5;
    public HingeJoint2D hingeJoint6;
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

        // Disable the useLimits of HingeJoint2D objects
        if (hingeJoint1 != null)
        {
            JointAngleLimits2D limits = hingeJoint1.limits;
            limits.max = 0;
            limits.min = 0;
            hingeJoint1.useLimits = false;
            Debug.Log("Limits disabled for HingeJoint1.");
        }

        if (hingeJoint2 != null)
        {
            JointAngleLimits2D limits = hingeJoint2.limits;
            limits.max = 0;
            limits.min = 0;
            hingeJoint2.useLimits = false;
            Debug.Log("Limits disabled for HingeJoint2.");
        }
        if (hingeJoint3 != null)
        {
            JointAngleLimits2D limits = hingeJoint3.limits;
            limits.max = 0;
            limits.min = 0;
            hingeJoint3.useLimits = false;
            Debug.Log("Limits disabled for HingeJoint3.");
        }

        if (hingeJoint4 != null)
        {
            JointAngleLimits2D limits = hingeJoint4.limits;
            limits.max = 0;
            limits.min = 0;
            hingeJoint4.useLimits = false;
            Debug.Log("Limits disabled for HingeJoint4.");
        }
        if (hingeJoint5 != null)
        {
            JointAngleLimits2D limits = hingeJoint5.limits;
            limits.max = 0;
            limits.min = 0;
            hingeJoint5.useLimits = false;
            Debug.Log("Limits disabled for HingeJoint5.");
        }

        if (hingeJoint6 != null)
        {
            JointAngleLimits2D limits = hingeJoint6.limits;
            limits.max = 0;
            limits.min = 0;
            hingeJoint6.useLimits = false;
            Debug.Log("Limits disabled for HingeJoint6.");
        }
        // Disable the "Balance" script
        balance balanceScript = GetComponentInChildren<balance>();

        if (balanceScript != null)
        {
            balanceScript.enabled = false;
            Debug.Log("Balance script disabled.");
        }
        else
        {
            Debug.LogError("Balance script not found in child objects.");
        }

        // Set the mass of the provided rigidbodies to one
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
