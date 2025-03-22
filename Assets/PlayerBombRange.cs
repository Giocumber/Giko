using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombRange : MonoBehaviour
{
    public Transform thisPlayer;
    public Transform otherPlayer;
    public float detectionRange = 5f; // Maximum allowed distance between players
    public bool isPlayerInRange;

    private void Update()
    {
        if (thisPlayer == null || otherPlayer == null) return;

        // Check distance between Player 1 and Player 2
        float distance = Vector3.Distance(thisPlayer.position, otherPlayer.position);
        isPlayerInRange = distance <= detectionRange;
    }

    private void OnDrawGizmos()
    {
        if (thisPlayer == null) return;

        // Set Gizmo color (Green = in range, Red = out of range)
        Gizmos.color = isPlayerInRange ? Color.green : Color.red;

        // Draw a sphere around Player 1 to visualize the detection range
        Gizmos.DrawWireSphere(thisPlayer.position, detectionRange);
    }
}
