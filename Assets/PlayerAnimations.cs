using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Animator anim;

    private void Update()
    {
        if (playerMovement.isMoving)
            TriggerWalk();
        else
            TriggerIdle();
    }

    public void TriggerWalk()
    {
        anim.SetBool("Walking", true);
    }

    public void TriggerIdle()
    {
        anim.SetBool("Walking", false);
    }
}
