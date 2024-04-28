using UnityEngine;

public class ArmDetachListener : MonoBehaviour
{
    // Public fields to assign in the Unity Editor
    public FixedJoint2D rightArmJoint;
    public GameObject rightArmParticles;
    public FixedJoint2D leftArmJoint;
    public GameObject leftArmParticles;

    void Update()
    {
        // Check if the right arm's joint is broken
        if (rightArmJoint == null)
        {
            Debug.Log("borke ");
            // Ensure the particles GameObject is not already active

                rightArmParticles.SetActive(true);
            // Optionally, destroy or disable the joint component to avoid repeated checks
            Destroy(rightArmJoint);
            rightArmJoint = null;
        }

        // Check if the left arm's joint is broken
        if (leftArmJoint == null)
        {
            // Ensure the particles GameObject is not already active
  
                leftArmParticles.SetActive(true);
         
            // Optionally, destroy or disable the joint component to avoid repeated checks
            Destroy(leftArmJoint);
            leftArmJoint = null;
        }
    }
}
