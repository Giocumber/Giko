using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDance : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        AnimalDanceManager.Register(this);
    }

    private void OnDisable()
    {
        AnimalDanceManager.Unregister(this);
    }

    public void TriggerDance()
    {
        anim.SetTrigger("Dance");
    }
}
