using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public Animator transitionAnim;

    public void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void LoadNextScene()
    {
        transitionAnim.SetTrigger("TransitionClose");
        StartCoroutine(NextSceneRoutine());
    }

    private IEnumerator NextSceneRoutine()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        yield return new WaitForSeconds(2f);

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextSceneIndex);
        else
            SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void DisableRatDance()
    {
        AudioManager.Instance.UnplayRatDance();
    }
}
