using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    public Transform player;

    Vector3 vel = Vector3.zero;

    [Range(0.01f, 1f)]
    public float movSmoothness;

    Vector3 targetRotation;
    [Range(0.01f, 1f)]
    public float rotTime;

    // Start is called before the first frame update
    void Start()
    {
        targetRotation = Vector3.zero;
        movSmoothness = 0.5f;
        rotTime = 0.5f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            targetRotation += new Vector3(0, 90, 0);
        }
        FollowPlayer();  //Follow the player 
        RotateCamera(); //Rotates the camera 90 degrees if the key R is pressed
    }

    void FollowPlayer()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position, ref vel, movSmoothness);
    }

    void RotateCamera()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * rotTime * 10);
    }
}
