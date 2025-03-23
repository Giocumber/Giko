using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monke : MonoBehaviour
{
    private Animator anim;
    public float throwInterval = 2f;
    public GameObject bananaPrefab;
    public float minRotation = -30f; // Minimum rotation before throwing
    public float maxRotation = 30f;  // Maximum rotation before throwing
    public float detectionRadius = 5f; // Detection range
    public LayerMask playerLayer; // Assign "Player" layer in Inspector

    private bool isThrowing = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check if a player is within range
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);
        bool playerInRange = hits.Length > 0;

        if (playerInRange && !isThrowing)
        {
            // Start throwing if the player is detected
            isThrowing = true;
            CancelInvoke(nameof(ThrowBanana)); // Ensure no duplicate invokes
            InvokeRepeating(nameof(ThrowBanana), 0f, throwInterval);
        }
        else if (!playerInRange && isThrowing)
        {
            // Stop throwing if the player is out of range
            isThrowing = false;
            CancelInvoke(nameof(ThrowBanana));
        }
    }

    private void ThrowBanana()
    {
        anim.SetTrigger("ThrowBanana");

        // Set a fixed rotation within min and max range
        float randomRotation = Random.Range(minRotation, maxRotation);
        transform.rotation = Quaternion.Euler(0, randomRotation, 0);

        // Instantiate the banana at Monke's position, facing Monke's forward direction
        Instantiate(bananaPrefab, transform.position + transform.forward, transform.rotation);
    }

    // 🟢 Draw Detection Radius in Scene View
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green; // Green circle
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
