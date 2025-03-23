using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    public PlayerManager playerManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            Debug.Log("CheckPoint!");
            playerManager.SetCheckPoint(other.transform);
        }
    }
}
