using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SaveOriginalPosition : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Vector3 storedPosition;
    private Quaternion storedRotation;
    private XRGrabInteractable grabInteractable;
    private Collider parentCollider; // Reference to the parent GameObject's collider for collision detection


    void Start()
    {
        // Store the original position and rotation when the script starts
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        storedPosition = originalPosition;
        storedRotation = originalRotation;

    
        // Get the XRGrabInteractable component attached to this object
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Get the parent GameObject's collider for collision detection
        parentCollider = transform.parent.GetComponent<Collider>();

        // Subscribe to the onFirstHoverEntered event to reset position when grabbing starts
        if (grabInteractable != null)
        {
            grabInteractable.onFirstHoverEntered.AddListener(OnFirstHoverEntered);
        }

       
    }

    private void OnFirstHoverEntered(XRBaseInteractor interactor)
    {
        // Store the current position and rotation as the grabbed position
        storedPosition = transform.position;
        storedRotation = transform.rotation;
    }

    public void ResetToOriginalPosition()
    {
        // Reset the object's position and rotation to its original values
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        storedPosition = originalPosition;
        storedRotation = originalRotation;
    }

    void Update()
    {
        // Check if the object collides with the parent collider and reset it if needed
        if (parentCollider != null && parentCollider.bounds.Intersects(GetComponent<Collider>().bounds))
        {
            transform.position = originalPosition;
            transform.rotation = originalRotation;
            storedPosition = originalPosition;
            storedRotation = originalRotation;
        }
    }


    
}
