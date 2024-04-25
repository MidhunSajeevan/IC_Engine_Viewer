using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{

    public  UnityAction OnResetButtonClick;


    public void OnRecombined()
    {
        OnResetButtonClick.Invoke();
    }
}
