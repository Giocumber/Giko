using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("AudioClips")]
    public AudioClip explosion;
    public AudioClip checkpoint;

    [Header("AudioSrc")]
    public AudioSource audioSrcSFX;
    public AudioSource audioSrcBGM;

    private void Awake()
    {
        // Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Optional: Keep across scenes
    }

    public void PlayExplosionSFX()
    {
        StartCoroutine(StartExplosionSFX());
    }

    private IEnumerator StartExplosionSFX()
    {
        yield return new WaitForSeconds(0.05f);
        audioSrcSFX.PlayOneShot(explosion);
    }

    public void PlayCheckpointSFX()
    {
        audioSrcSFX.PlayOneShot(checkpoint);
    }

    public void PlayRatDance()
    {
        audioSrcBGM.Play();
    }

    public void UnplayRatDance()
    {
        audioSrcBGM.Stop();
    }
}
