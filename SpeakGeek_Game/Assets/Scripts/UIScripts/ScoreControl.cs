using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI; 

public class ScoreControl : MonoBehaviour
{
    public int astronaut;

    //collection types
    public int bigFamily;
    public int smallFamily;
    public int duo;
    public int solo; 

    //numeric score text
    public TMP_Text scoreText;

    public Slider scoreSlider;

    //progress description text
    public TMP_Text progressText;

    //particle effects
    public ParticleSystem collectEffect;
    public ParticleSystem hitEffect;

    //audio sources
    public AudioSource collectSound;
    public AudioSource hitSound;

    public GameManager manager;

    public Rigidbody rb;

    //bools to change end game results
    public bool lowEnd;
    public bool highEnd;
    public bool mediumEnd;

    public void Start()
    {
        //set up game start up
        progressText.text = "Uninhabitable...";
        astronaut = 0;
        scoreText.text = astronaut.ToString();
        scoreSlider.value = 0;
       
    }

    public void Update()
    {
        //condition for failure
        if(astronaut <= 40)
        {
            progressText.text = "Uninhabitable...";
            lowEnd = true;
            mediumEnd = false;
            highEnd = false;
        }

        //condition for mediocre pass
        if (astronaut > 40)
        {
            progressText.text = "Getting there";
            mediumEnd = true;
            lowEnd=false;
            highEnd=false;
        }

        //condition for good pass
        if (astronaut > 75)
        {
            progressText.text = "Habitable!";
            highEnd = true;
            mediumEnd = false;
            lowEnd=false;
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        //collection of big group
        if(other.gameObject.tag == "big")
        {
            //make objects dissappear
            other.gameObject.SetActive(false);

            //play particle effect and sound
            collectEffect.Play();
            collectSound.Play();

            //increase score
            astronaut += 10;

            //display progress
            scoreText.text = astronaut.ToString();
            scoreSlider.value = astronaut;
            
        }

        //collection of small group
        if (other.gameObject.tag == "small")
        {
            //make objects dissappear
            other.gameObject.SetActive(false);

            //play particle effect and sound
            collectEffect.Play();
            collectSound.Play();

            //increase score
            astronaut += 5;

            //display progress
            scoreText.text = astronaut.ToString();
            scoreSlider.value = astronaut;
        }

        //collection of pair
        if (other.gameObject.tag == "duo")
        {
            //make objects dissappear
            other.gameObject.SetActive(false);

            //play particle effect and sound
            collectEffect.Play();
            collectSound.Play();

            //increase score
            astronaut += 2;

            //display progress
            scoreText.text = astronaut.ToString();
            scoreSlider.value = astronaut;
        }

        //collection of single object
        if (other.gameObject.tag == "solo")
        {
            //make objects dissappear
            other.gameObject.SetActive(false);

            //play particle effect and sound
            collectEffect.Play();
            collectSound.Play();

            //increase score
            astronaut += 1;

            //display progress
            scoreText.text = astronaut.ToString();
            scoreSlider.value = astronaut;
        }    
        
        //trigger game over
        if(other.gameObject.tag == "complete")
        {
            //freeze the player
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.constraints = RigidbodyConstraints.FreezeRotation;

            //condition for game end on low score
            if (lowEnd)
            {
                manager.GameEndOne();
            }

            //condition for game end on average score
            if (mediumEnd)
            {
                manager.GameEndTwo();
            }

            //condition for game end on high score
            if (highEnd)
            {
                manager.GameEndThree();
            }
        }

        
    }


    public void OnCollisionEnter(Collision other)
    {
        //collision detection for rocks 
        if (other.gameObject.tag == "obstacle" )
        {
            //play particle effect and sound
            hitEffect.Play();
            hitSound.Play();

            //decrease score
            astronaut -= 5;

            //ensure that score is never a negative value
            if (astronaut < 0)
            {
                astronaut = 0;
            }

            //display progress
            scoreText.text = astronaut.ToString();
            scoreSlider.value = astronaut;
        }

        //collision detection for spinning obstacle
        if (other.gameObject.tag == "spin")
        {
            //play particle effect and sound
            hitEffect.Play();
            hitSound.Play();

            //decrease score
            astronaut -= 8;

            //ensure that score is never a negative value
            if (astronaut < 0)
            {
                astronaut = 0;
            }

            //display progress
            scoreText.text = astronaut.ToString();
            scoreSlider.value = astronaut;
        }

        //collision detection for patrol enemy
        if (other.gameObject.tag == "enemy")
        {
            //play particle effect and sound
            hitEffect.Play();
            hitSound.Play();

            //decrease score
            astronaut -= 15;

            //ensure that score is never a negative value
            if(astronaut < 0)
            {
                astronaut = 0;
            }

            //display progress
            scoreText.text = astronaut.ToString();
            scoreSlider.value = astronaut;
        }
    }

}
