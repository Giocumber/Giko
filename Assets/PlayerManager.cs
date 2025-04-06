using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public GameObject player1Canvas;
    public GameObject player2Canvas;
    private Transform checkPoint;

    public void SpawnPlayer()
    {
        //PlayerMovement movement1 = player1.GetComponent<PlayerMovement>();
        //if (movement1 != null)
        //    movement1.canMove = true;

        //PlayerMovement movement2 = player2.GetComponent<PlayerMovement>();
        //if (movement2 != null)
        //    movement2.canMove = true;

        StartCoroutine(StartSpawnPlayer());
    }

    private IEnumerator StartSpawnPlayer()
    {
        yield return new WaitForSeconds(2f);

        player1.SetActive(true);
        player2.SetActive(true);

        player1Canvas.SetActive(true);
        player2Canvas.SetActive(true);

        Vector3 spawnPoint1 = new Vector3(checkPoint.position.x - 1f, checkPoint.position.y, checkPoint.position.z);
        Vector3 spawnPoint2 = new Vector3(checkPoint.position.x + 1f, checkPoint.position.y, checkPoint.position.z);

        player1.transform.position = spawnPoint1;
        player2.transform.position = spawnPoint2;
    }

    public void SetCheckPoint(Transform newCheckpoint)
    {
        checkPoint = newCheckpoint;
    }

}
