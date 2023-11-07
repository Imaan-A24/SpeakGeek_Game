using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    public void Start()
    {
        //find space between player and camera
        offset = transform.position - player.transform.position; 
    }

    public void LateUpdate()
    {
        //follow player
        transform.position = player.transform.position + offset; 
    }

}
