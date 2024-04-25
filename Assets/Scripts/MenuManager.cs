using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject MenuGameObject;
    public InputActionProperty inputActionProperty;
    public Transform PlayerTransform;
   
    // Update is called once per frame
    void Update()
    {
        //if(inputActionProperty.action.WasPressedThisFrame())
        //{
        //    MenuGameObject.SetActive(!MenuGameObject.activeSelf);
        //    MenuGameObject.transform.position = PlayerTransform.position + new Vector3(PlayerTransform.forward.x, 0, PlayerTransform.forward.z).normalized * 2f;

        //}
        MenuGameObject.transform.LookAt(PlayerTransform.forward);
        transform.forward *= -1; 
    }
}
