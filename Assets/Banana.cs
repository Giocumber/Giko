using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    public float speed = 5f;

    private void Start()
    {
        Destroy(gameObject, 4f); // Destroy banana after 5 seconds to prevent clutter
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerBombRange[] playerBombRanges = FindObjectsOfType<PlayerBombRange>();

            foreach(PlayerBombRange playerBombRange in playerBombRanges)
                playerBombRange.ExplodeGiko();
        }
    }
}
