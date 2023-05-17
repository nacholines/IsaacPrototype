using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimationController : AnimationController
{
    public override void SendAnimationStatus(AnimationStatus status)
    {
        MovementAnimationStatus newStatus;
        try
        {
            newStatus = (MovementAnimationStatus)status;
        }
        catch { return; }

        animator.SetBool("isIdle", newStatus.isIdle);
        animator.SetBool("isMoving", newStatus.isMoving);
        animator.SetBool("isFacingRight", newStatus.isFacingRight);
        animator.SetBool("isFacingLeft", newStatus.isFacingLeft);
        animator.SetBool("isFacingDown", newStatus.isFacingDown);
        animator.SetBool("isFacingUp", newStatus.isFacingUp);
    }
}