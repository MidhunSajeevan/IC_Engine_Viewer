using UnityEngine;

public class RotateCanvasToCamera : MonoBehaviour
{
    private Transform mainCameraTransform;

    void Start()
    {
        // Get a reference to the main camera's transform
        mainCameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Rotate the canvas to face the camera's position
        transform.LookAt(mainCameraTransform);
        transform.forward *= -1;

    }
}
