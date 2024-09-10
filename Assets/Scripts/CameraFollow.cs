using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Follows the player with a smooth camera movement and clamps the camera within defined boundaries.
/// Attach this script to the camera object.
/// </summary>
/// <param name="player">The player object to follow</param>
/// <param name="offset">The offset from the player's position</param>
/// <param name="smoothSpeed">The speed at which the camera moves to the desired position</param>
/// <param name="leftBoundary">The left and bottom boundaries for the camera</param>
/// <param name="rightBoundary">The right and top boundaries for the camera</param>
public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    // Define boundaries for the camera
    public Vector2 leftBoundary = new Vector2(2, 2);
    public Vector2 rightBoundary = new Vector2(10, 10); // Example right boundary

    void LateUpdate()
    {
        // Calculate the desired camera position based on player position and offset
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

        // Clamp the camera's position within the defined boundaries
        float clampedX = Mathf.Clamp(desiredPosition.x, leftBoundary.x, rightBoundary.x);
        float clampedY = Mathf.Clamp(desiredPosition.y, leftBoundary.y, rightBoundary.y);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        // Smoothly move the camera to the clamped position
        Vector3 smoothPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);
        transform.position = smoothPosition;
    }
}
