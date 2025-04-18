using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandleCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hazard"))
        {
            AudioManager.Instance.PlayExplosionSFX();
            PlayerBombRange[] playerBombRanges = FindObjectsOfType<PlayerBombRange>();

            foreach (PlayerBombRange playerBombRange in playerBombRanges)
                playerBombRange.ExplodeGiko();
        }
    }
}
