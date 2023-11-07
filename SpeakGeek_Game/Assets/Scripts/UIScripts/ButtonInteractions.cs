using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonInteractions : MonoBehaviour
{
    public void StartGame() 
    {
        SceneManager.LoadScene("HowToPlay", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void Begin()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
