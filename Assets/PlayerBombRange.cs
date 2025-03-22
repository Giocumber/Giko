using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombRange : MonoBehaviour
{
    public Transform thisPlayer;
    public Transform otherPlayer;
    public float detectionRange = 5f; // Maximum allowed distance between players
    public bool isPlayerInRange;
    public GameObject ExplosionVFX;
    public GameObject rangeCanvas;
    public PlayerManager playerManager;

    private void Update()
    {
        if (thisPlayer == null || otherPlayer == null) return;

        // Check distance between Player 1 and Player 2
        float distance = Vector3.Distance(thisPlayer.position, otherPlayer.position);
        isPlayerInRange = distance <= detectionRange;

        if (!isPlayerInRange)
            ExplodeGiko();
    }

    private void ExplodeGiko()
    {
        isPlayerInRange = true;
        playerManager.SpawnPlayer();
        gameObject.SetActive(false);
        rangeCanvas.SetActive(false);
        Instantiate(ExplosionVFX, transform.position, ExplosionVFX.transform.rotation);
    }

}
