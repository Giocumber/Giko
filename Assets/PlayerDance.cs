using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDance : MonoBehaviour
{
    private Animator anim;
    private PlayerMovement playerMovement;

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void TriggerDance()
    {
        playerMovement.canMove = false;
        anim.SetTrigger("Dance");
    }
}
