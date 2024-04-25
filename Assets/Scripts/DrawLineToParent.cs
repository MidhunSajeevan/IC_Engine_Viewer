using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DrawLineToParent : MonoBehaviour
{
  
    private LineRenderer lineRenderer; // Line Renderer component

     Transform childObject;
    Transform parentObject;
    XRGrabInteractable interactable;
    void Start()
    {
        childObject = transform;
        interactable = GetComponent<XRGrabInteractable>();
        lineRenderer = FindAnyObjectByType<LineRenderer>();
        if (lineRenderer == null)
        {
            Debug.LogError("Missing references! Make sure to assign the child object and Line Renderer component.");
            return;
        }

        // Get the parent object at runtime
         parentObject = transform.parent;

        if (parentObject == null)
        {
            Debug.LogError("Parent object not found!");
            return;
        }

        // Set up the Line Renderer properties
        lineRenderer.positionCount = 2;
      

        // Update the line positions initially
        UpdateLinePositions();
    }

  

    public void UpdateLinePositions( )
    {
        // Set the line positions based on the parent and child object positions
        lineRenderer.SetPosition(0, parentObject.position);
        lineRenderer.SetPosition(1, childObject.position);
    }
    public void FixedUpdate()
    {
        
        if(interactable.isSelected)
        {
            Debug.Log("Line Selected");
            UpdateLinePositions();
        }
        else
        {
            RemoveLinePositions();
        }
       
    }
     void RemoveLinePositions()
    {
        // Set the line positions based on the parent and child object positions
     
        lineRenderer.SetPosition(0,new Vector3(0,0,0));
        lineRenderer.SetPosition(1, new Vector3(0, 0, 0));
    }
}
