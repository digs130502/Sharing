using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    [SerializeField] Vector2 areaSize = new Vector2(10, 10);
    [SerializeField] Transform player;
    [SerializeField] float smallCameraSize = 5f;
    [SerializeField] float bigCameraSize = 3f;
    [SerializeField] Vector3 smallOffset = new Vector3(0f, 2f, -10f);
    [SerializeField] Vector3 bigOffset = new Vector3(0f, 5f, -10f);
    private Camera mainCamera;
    private CameraFollow cameraFollow;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        mainCamera.orthographicSize = smallCameraSize;
        cameraFollow = mainCamera.GetComponent<CameraFollow>();

        if (cameraFollow != null)
        {
            cameraFollow.offset = smallOffset; // initial offset
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerOutsideArea())
        {
            mainCamera.orthographicSize = smallCameraSize;
            if (cameraFollow != null) cameraFollow.offset = smallOffset;
            Debug.Log("small camera size");
        }
        else
        {
            mainCamera.orthographicSize = bigCameraSize;
            if (cameraFollow != null) cameraFollow.offset = bigOffset;
            Debug.Log("big camera size");
        }
    }

    bool IsPlayerOutsideArea()
    {
        // Calculate the boundaries
        Vector2 minBoundary = (Vector2)transform.position - areaSize / 2;
        Vector2 maxBoundary = (Vector2)transform.position + areaSize / 2;

        // Check if player is outside the boundaries
        if (player.position.x < minBoundary.x || player.position.x > maxBoundary.x || player.position.y < minBoundary.y || player.position.y > maxBoundary.y)
        {
            return true; //Player is outside the area
        }

        return false; // Player is inside the area

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, areaSize);

        // Calculate and draw the exact boundaries of the area
        Vector2 minBoundary = (Vector2)transform.position - areaSize / 2;
        Vector2 maxBoundary = (Vector2)transform.position + areaSize / 2;

        // Draw corners of the boundary box for clarity
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(minBoundary, 0.2f); // Bottom-left corner
        Gizmos.DrawSphere(maxBoundary, 0.2f); // Top-right corner
        Gizmos.DrawSphere(new Vector2(minBoundary.x, maxBoundary.y), 0.2f); // Top-left corner
        Gizmos.DrawSphere(new Vector2(maxBoundary.x, minBoundary.y), 0.2f); // Bottom-right corner
    }
}
