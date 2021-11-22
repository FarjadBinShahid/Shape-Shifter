using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;

    void Awake()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        //DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageInput();
    }

    void ManageInput()
    {
        
    }

    void PauseGame()
    {
        
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        UIHandler.Instance.GameOver();
    }
}
