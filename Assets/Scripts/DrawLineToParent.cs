using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
public class DrawLineToParent : MonoBehaviour
{

    [SerializeField] private string NameOfObject;
    private LineRenderer lineRenderer; // Line Renderer component

     Transform childObject;
    Transform parentObject;
    XRGrabInteractable interactable;
    TextMeshProUGUI textMeshProUGUI;
    Canvas canvas;
    void Start()
    {
        childObject = transform;
        canvas = GameObject.Find("NameDisplayCanvas").GetComponent<Canvas>();
        textMeshProUGUI = canvas.GetComponentInChildren<TextMeshProUGUI>();


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
      

        //Disable the canvas First
         canvas.gameObject.SetActive(false);
      
        // Update the line positions initially
        UpdateLinePositions();
    }

  

    public void UpdateLinePositions( )
    {
        canvas.gameObject.SetActive(true);
        // Set the line positions based on the parent and child object positions
        lineRenderer.SetPosition(0, parentObject.position);
        lineRenderer.SetPosition(1, childObject.position);

        //Set Name when the update postion called
        canvas.transform.position = childObject.position;
        textMeshProUGUI.text = NameOfObject;

    }
    public void FixedUpdate()
    {
        
        if(interactable.isSelected)
        {

            UpdateLinePositions();
        }
       
       
    }
     void RemoveLinePositions()
    {
        // Set the line positions based on the parent and child object positions
     
        lineRenderer.SetPosition(0,new Vector3(0,0,0));
        lineRenderer.SetPosition(1, new Vector3(0, 0, 0));
    }
}
