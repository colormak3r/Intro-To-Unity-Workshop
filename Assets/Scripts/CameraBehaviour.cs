using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform target;  // The target that the camera will follow
    public Vector3 offset = new Vector3(0, 0, -10);    // The offset between the camera and target
    public float smoothSpeed = 0.125f; // How smoothly the camera follows

    private Vector3 currentVelocity;
    void FixedUpdate()
    {
        if (target == null) return;

        // Desired position of the camera based on the target's position and offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate between the camera's current position and the desired position
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothSpeed);

        // Update the camera's position
        transform.position = smoothedPosition;
    }
}
