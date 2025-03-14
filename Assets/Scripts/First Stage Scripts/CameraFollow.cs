using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target to follow (your character)
    public float distance = 5.0f; // Distance from the target
    public float height = 1.0f; // Height above the target
    public float smoothSpeed = 0.125f; // Speed of the camera movement

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position in front of the target
            Vector3 desiredPosition = target.position - target.forward * distance + Vector3.up * height;

            // Smoothly interpolate to the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // Update camera position
            transform.position = smoothedPosition;

            // Make the camera look at the target
            transform.LookAt(target);
        }
    }
}