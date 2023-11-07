using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //fade effects
    public GameObject fadeIn;
    public GameObject fadeOut;

    public PlayerController player;

    //game over panels
    public GameObject uninhabitable;
    public GameObject ehh;
    public GameObject habitable;

    //bools to check end game state
    public bool low = false;
    public bool high = false;
    public bool medium = false;



    void Start()
    {
        FadeIn();        
    }

    void Update()
    {
        //shortcut to return to main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

        //game end result for low score
        if (low)
        {            
            uninhabitable.SetActive(true);
            Invoke("Return", 7f);
        }

        //game end result for average score
        if (medium)
        {            
            ehh.SetActive(true);
            Invoke("Return", 7f);
        }

        //game end result for high score
        if (high)
        {           
            habitable.SetActive(true);
            Invoke("Return", 7f);
        }
    }

    //control fade out effect
    public void FadeOut()
    {
        fadeIn.SetActive(false);
        fadeOut.SetActive(true);
        player.FreezePos();
    }

    //control fade in effect
    public void FadeIn()
    {
        fadeOut.SetActive(false);
        fadeIn.SetActive(true);
    }

    //restart the game
    public void Restart()
    {
        fadeOut.SetActive(false);
        fadeIn.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("back");
    }

    //set end result to low score
    public void GameEndOne()
    {
        low = true;
    }

    //set end result to average score
    public void GameEndTwo()
    {
        medium = true;
    }

    //set end result to high score
    public void GameEndThree()
    {
        high = true;
    }

    //automatically load main menu on game end
    public void Return()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
