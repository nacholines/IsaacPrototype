using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationController : MonoBehaviour
{
    protected Animator animator;
    public abstract void SendAnimationStatus(AnimationStatus status);

    protected void Awake()
    {
        animator = GetComponent<Animator>();
    }
}