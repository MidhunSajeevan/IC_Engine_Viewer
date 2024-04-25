using UnityEngine;

public class ResetObjectToInitial : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 initialScale;
    private Events events;

    void Start()
    {
        // Find the Events script instance in the scene
        events = FindObjectOfType<Events>();

        // Check if the Events script instance was found
        if (events != null)
        {
            // Subscribe to the OnResetButtonClick event
            events.OnResetButtonClick += ResetToInitial;
        }
        else
        {
            Debug.LogError("Events script not found in the scene!");
        }

        // Store the initial transform values when the script starts
        StoreInitialTransform();
    }

    void StoreInitialTransform()
    {
        // Store the initial position, rotation, and scale
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        initialScale = transform.localScale;
    }

    public void ResetToInitial()
    {
        // Reset the object to its initial transform values
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        transform.localScale = initialScale;
    }
}
