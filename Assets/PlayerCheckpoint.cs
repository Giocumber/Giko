using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCheckpoint : MonoBehaviour
{
    private PlayerManager playerManager;
    private Animator checkpointAnim;

    public bool checkpointTriggered = false;
    public GameObject checkpointVFX;
    public Image checkpointRing;
    public Color checkpointTakenColor;

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
                AudioManager.Instance.PlayCheckpointSFX();
                checkpointAnim.SetTrigger("CheckPointTaken");
                checkpointTriggered = true;
                checkpointVFX.SetActive(true);
                checkpointRing.color = checkpointTakenColor;
            }

            playerManager.SetCheckPoint(transform);
        }
    }
}
