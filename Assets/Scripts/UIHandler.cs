using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject gameOverScreen;

    public static UIHandler Instance;


    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
        pauseScreen.SetActive(false);
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
    }


    public void RestartGame()
    {
        ResumeGame();
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void GoToMainMenu()
    {
        ResumeGame();
        SceneManager.LoadScene(0);
    }

    
}
