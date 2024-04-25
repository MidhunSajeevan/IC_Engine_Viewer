using System.Collections;
using UnityEngine;

public class AnimationBhehavior : MonoBehaviour
{
    [SerializeField]Animator animator;
   
    public void OnDisassembleButtonClick()
    {
     
        animator.enabled = true;
        animator.SetBool("Play",true);
        StartCoroutine(stopanmation());
    }

    IEnumerator stopanmation()
    {
        yield return new WaitForSeconds(3f);
        animator.enabled = false;
    }
}
