using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    private Transform checkPoint;

    public void SpawnPlayer()
    {
        StartCoroutine(StartSpawnPlayer());
    }

    private IEnumerator StartSpawnPlayer()
    {
        yield return new WaitForSeconds(2f);

        player1.SetActive(true);
        player2.SetActive(true);
        player1.transform.position = checkPoint.position;
        player2.transform.position = checkPoint.position;
    }

    public void SetCheckPoint(Transform newCheckpoint)
    {
        checkPoint = newCheckpoint;
    }
}
