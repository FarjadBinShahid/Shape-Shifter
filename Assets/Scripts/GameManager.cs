using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance; // static Instance to access GameManager without any object or reference

    void Awake()
    {
        if(Instance!=null) // checks if there is an existing object of Game Manager::: Destroy gameobject if there is an existing object
        {
            Destroy(gameObject); 
            return; 
        }

        Instance = this; // change Instance to new one
        //DontDestroyOnLoad(gameObject);
    }


    //method to do some gameover time tasks
    public void GameOver()
    {
        Debug.Log("here");
        Time.timeScale = 0; // pause the game so user can not interact with game after game is over
        UIHandler.Instance.GameOver(); // calls Game over method from another class to enable Gameover screen
    }
}
