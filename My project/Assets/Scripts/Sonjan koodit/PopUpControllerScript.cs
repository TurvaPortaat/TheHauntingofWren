using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpControllerScript : MonoBehaviour
{
  public void Show(Animator animator)
    {
        animator.SetBool("visible", true);
    }
    public void Hide(Animator animator)
    {
        animator.SetBool("visible", false);
    }
}
