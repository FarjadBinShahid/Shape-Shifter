using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen; // pauseScreen reference
    [SerializeField] private GameObject gameOverScreen; // game over screen reference

    public static UIHandler Instance; // static Instance to access GameManager without any object or reference from any script


    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // disabling all UI screens
        pauseScreen.SetActive(false); 
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //checks if user presses escape, pauses the game if pressed
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }


//to pause the game
    public void PauseGame()
    {
        Time.timeScale = 0f; // sets timescale to 0 so everything is stopped
        pauseScreen.SetActive(true); 
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; //setting timescale to 1 so everything is back to normal time
        pauseScreen.SetActive(false);
    }


    public void RestartGame()
    {
        ResumeGame(); // calls resume game so puase screen is disabled and timescale is set to 1 again
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(1); //reload the scene to restart the game
    }


    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void GoToMainMenu()
    {
        ResumeGame();
        SceneManager.LoadScene(0); // load the main menu scene
    }

    
}
