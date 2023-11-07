using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jump;
    private Rigidbody rb;

    public bool onGround = true;

    public Transform spawnPoint;
    public float spawnDistance;

    public GameManager manager;      

   

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        //check if the player has fallen off the course
        if (this.transform.position.y < -spawnDistance)
        {
            manager.FadeOut();
        }

    }

    public void FixedUpdate() 
    {
        //player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        //player jump
        if(Input.GetKey(KeyCode.Space) && onGround)
        {
            rb.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //ground check for jump
        if(collision.gameObject.tag == "ground")
        {
            onGround = true;
        }
    }
    
    //freeze player position when fallen
    public void FreezePos()
    {
        rb.constraints = RigidbodyConstraints.FreezePosition;
        Invoke("RespawnPos", 5f);
    }

    //respawn player after fade
    public void RespawnPos()
    {
        transform.position = spawnPoint.position;
        Debug.Log("back");
        manager.Restart();
    }

}
