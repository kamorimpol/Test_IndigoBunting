using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void DisableAnimations()
    {
        animator.enabled = false;
    }

    public void EnableDancing()
    {
        animator.enabled = true;
        animator.SetTrigger("dancing");
    }
}
