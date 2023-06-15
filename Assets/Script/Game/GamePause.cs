using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Change KeyCode.Space to the desired pause/resume button
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f; // Pauses the game by setting the time scale to 0
            isPaused = true;
            // Additional code to display a pause menu, hide UI elements, or perform any other necessary tasks when the game is paused
        }
    }

    public void ResumeGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1f; // Resumes the game by setting the time scale back to 1
            isPaused = false;
            // Additional code to hide the pause menu, show UI elements, or perform any other necessary tasks when the game is resumed
        }
    }
}


