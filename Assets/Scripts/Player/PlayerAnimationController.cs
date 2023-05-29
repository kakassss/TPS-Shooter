using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator;
    
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void IdleToRun(string IdleToRun, float Input)
    {
        animator.SetFloat(IdleToRun,Input);
    }
    public void Jump(bool canJump)
    {
        animator.SetBool("Jump",canJump);
    }

    public void Aiming(bool canAim)
    {
        animator.SetBool("IsAiming",canAim);
    }
}
