using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIHandler : MonoBehaviour
{

    //Load the Main scene to start the gameplay :: trigger when user press Start game button
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
