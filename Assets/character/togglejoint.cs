using UnityEngine;

public class HingeJointToggle : MonoBehaviour
{
    private HingeJoint2D hingeJoint;

    private void Awake()
    {
        // Get the HingeJoint2D component attached to this GameObject
        hingeJoint = GetComponent<HingeJoint2D>();
    }

    // Public function to toggle the HingeJoint2D
    public void ToggleJoint()
    {
        if (hingeJoint != null)
        {
            // Toggle the enabled state of the HingeJoint2D
            hingeJoint.enabled = !hingeJoint.enabled;
        }
        else
        {
            Debug.LogError("HingeJoint2D component not found on this GameObject!");
        }
    }
}