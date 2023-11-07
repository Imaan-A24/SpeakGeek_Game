using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed = 6;
    public float pause;

    public Transform pointA;
    public Transform pointB;


    //enemy patrols between two points
    IEnumerator Start() 
    {
        Transform target = pointA;
        while (true)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            
            if(Vector3.Distance(transform.position, target.position) <= 0)
            {
                target = target == pointA ? pointB : pointA;
                yield return new WaitForSeconds(pause);
            }
            yield return null;
        }
    }


    //Enemy temporarily stops moving when colliding with player
    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player") 
        {
            speed = 0;
        }

    }


    public void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Invoke("MoveAgain", 1f);
        }
    }

    //Enemy speed set back to normal after collision with player
    public void MoveAgain()
    {
        speed = 6; 
    }
}
