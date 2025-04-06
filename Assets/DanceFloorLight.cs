using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceFloorLight : MonoBehaviour
{
    public Light danceLight;
    public float flashSpeed = 0.2f; // time between flashes
    public float maxIntensity = 2f;
    public float minIntensity = 0f;

    private Coroutine flashRoutine;

    public void TriggerDanceLight()
    {
        if (flashRoutine != null)
            StopCoroutine(flashRoutine);

        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        while (true)
        {
            // Random color
            danceLight.color = new Color(Random.value, Random.value, Random.value);

            // Toggle intensity between min and max
            danceLight.intensity = (danceLight.intensity == maxIntensity) ? minIntensity : maxIntensity;

            yield return new WaitForSeconds(flashSpeed);
        }
    }
}
