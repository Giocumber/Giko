using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject blurPanel;

    private void Start()
    {
        Time.timeScale = 1f;  // Freezes the game
    }

    public void PauseGame()
    {
        blurPanel.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;  // Freezes the game
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;  // Resumes the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void LoadFirstScene()
    {
        Time.timeScale = 1f;  // Ensure the game is not paused when loading
        SceneManager.LoadScene(0);  // Load the first scene (index 0)
    }
}
