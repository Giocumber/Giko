using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceFloor : MonoBehaviour
{
    public Vector3 dancePosition1;
    public Vector3 dancePosition2;
    private int numOfDancer = 0;

    public DanceFloorLight danceFloorLight;
    public GameObject endCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerDance playerDance = other.GetComponent<PlayerDance>();

            if(numOfDancer == 0)
            {
                other.transform.position = transform.position + dancePosition1;
                numOfDancer++;
            }
            else
            {
                other.transform.position = transform.position + dancePosition2;
                AudioManager.Instance.PlayRatDance();
                AnimalDanceManager.TriggerAllDances();
                danceFloorLight.TriggerDanceLight();
                StartCoroutine(EnableEndCanvas());
            }

            playerDance.TriggerDance();
        }
    }

    private IEnumerator EnableEndCanvas()
    {
        yield return new WaitForSeconds(2f);
        endCanvas.SetActive(true);
    }
}
