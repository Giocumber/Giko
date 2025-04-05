using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    private PlayerManager playerManager;
    private Animator checkpointAnim;

    public bool checkpointTriggered = false;
    public GameObject checkpointVFX;

    private void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        checkpointAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!checkpointTriggered)
            {
                checkpointAnim.SetTrigger("CheckPointTaken");
                checkpointTriggered = true;
                checkpointVFX.SetActive(true);
            }

            playerManager.SetCheckPoint(transform);
        }
    }
}
